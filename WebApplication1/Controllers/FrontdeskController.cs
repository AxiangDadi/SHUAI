using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class FrontdeskController : Controller
    {
     
        KeeperServices ks = new KeeperServices();
        OrderServices os = new OrderServices();
        StateServices ss = new StateServices();
        TypeServices ts = new TypeServices();
        SizeServices si = new SizeServices();
        EvaluationServices es = new EvaluationServices();
        UserServices us = new UserServices();
        GoodsServices gs = new GoodsServices();

        /// <summary>
        /// 分装提示的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dizhi"></param>
        /// <returns></returns>
        public string Ts(string name, string dizhi)
        {
            string s = "<script>alert('" + name + "!');window.location.href='" + dizhi + "'</script>";
            return s;

        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Longin()
        {

            return View();
        }

        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public ActionResult Dl(Keeper k) {

            int i = ks.Longin(k);
            if (i > 0)
            {
                Session["name"] = k.KName;
                return View("Index");
            }
            else
            {

                return Content("<script>alert('用户名与密码不正确');window.location.href='../Frontdesk/Longin';</script>");
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult zhuxiao()
        {
            Session["name"] = null;
          return Content(Ts("注销成功!", "../Frontdesk/Longin"));

        }

        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        // GET: Frontdesk
        public ActionResult Index()
        {
           
            if (Session["name"] != null)
            {
                return View();
            }
            else {
                return Content(Ts("请先登录!", "../Frontdesk/Longin"));
            }
          
        }

        /// <summary>
        /// 桌面页面
        /// </summary>
        /// <returns></returns>
        public ActionResult welcome()
        {
            if (Session["name"] != null)
            {
                return View();
            }
            else
            {
                return Content(Ts("请先登录!", "../Frontdesk/Longin"));
            }
        }

        /// <summary>
        /// 商品类型查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductManager()
        {
           ViewData.Model = ts.select();
            return View();
        }

        /// <summary>
        /// 添加商品类型
        /// </summary>
        /// <param name="ty"></param>
        /// <returns></returns>
        public ActionResult AddProductManager(Model.Type ty) {
           bool i= ts.Add(ty);
            if (i)
            {
                return Content(Ts("添加成功","../Frontdesk/ProductManager"));
            }
            else {
                return Content(Ts("添加失败", "../Frontdesk/ProductManager"));
            }
       
        }

        /// <summary>
        /// 修改商品类型
        /// </summary>
        /// <param name="ty"></param>
        /// <returns></returns>
        public ActionResult UpdateProductManager(Model.Type ty) {

            bool i = ts.Update(ty);
            if (i)
            {
                return Content(Ts("修改成功", "../Frontdesk/ProductManager"));
            }
            else
            {
                return Content(Ts("修改失败", "../Frontdesk/ProductManager"));
            }
        
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ty"></param>
        /// <returns></returns>
        public ActionResult DeleProductManager(Model.Type ty) {
      
            bool i = ts.Delete(ty);
            if (i)
            {
                return Content(Ts("删除成功", "../Frontdesk/ProductManager"));
            }
            else
            {
                return Content(Ts("删除失败", "../Frontdesk/ProductManager"));
            }
         
        }
      
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult picture_list()
        {
        
            ViewBag.Xlk = ss.select();

            ViewData.Model = os.Cha();
              
            return View();
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public ActionResult Updatepicture_list(Order o)
        {
            int sid =(int) o.StateId;
            int i= os.Update(sid,o.OrderNumber);
            if (i>0)
            {
                return Content(Ts("修改成功", "../Frontdesk/picture_list"));
            }
            else
            {
                return Content(Ts("修改失败", "../Frontdesk/picture_list"));
            }


            return View();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public ActionResult Delepicture_list(Order o)
        {
          bool i=  os.Del(o);
            if (i)
            {
                return Content(Ts("删除成功", "../Frontdesk/picture_list"));
            }
            else
            {
                return Content(Ts("删除失败", "../Frontdesk/picture_list"));
            }
          
        }
        
        /// <summary>
        /// 商品管理
        /// </summary>
        /// <returns></returns>
        public ActionResult product_category()
        {
           ViewData.Model= gs.select();
            return View();
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdatePro(Goods g)
        {
            ViewBag.Xlk1 = ts.select();
            ViewBag.Xlk = si.select();

           List<Goods> list= gs.SelectBy(g.GoodsID);
            ViewData.Model = list;
            return View();
        }

        /// <summary>
        /// 修改提交做的操作
        /// </summary>
        /// <param name="files"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public ActionResult UpdateGoods(HttpPostedFileBase[] files,Goods g)
        {

            if (files[0] != null)
            {
                try
                {
                    var path = Server.MapPath("/tp");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    foreach (HttpPostedFileBase item in files)
                    {
                        string name = "";
                        if (files[0] != null)
                        {
                            Random rd = new Random();
                            string i = rd.Next().ToString();
                            name = i + ".jpg";
                            g.GoodsPic ="tp/"+name;
                        }

                     
                        item.SaveAs(Path.Combine(path, name));
                    }
                    bool i2= gs.Update(g);
                    if (i2)
                    {
                        return Content(Ts("修改成功", "../Frontdesk/product_category"));
                    }
                    else {
                        return Content(Ts("修改失败", "../Frontdesk/product_category"));
                    }
                    
                }
                catch (Exception ex)
                {
                    return Content(string.Format("上传文件出现异常：{0}", ex.Message));
                }
            }
            else
            {
                bool i2 = gs.Update(g);
                if (i2)
                {
                    return Content(Ts("修改成功", "../Frontdesk/product_category"));
                }
                else
                {
                    return Content(Ts("修改失败", "../Frontdesk/product_category"));
                }
            }
         
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPro()
        {
            ViewBag.Xlk1 = ts.select();
            return View();
        }

        /// <summary>
        /// 提交商品新增
        /// </summary>
        /// <param name="files"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public ActionResult TjAdd(HttpPostedFileBase[] files, Goods g) {
            
            if (files[0] != null)
            {
                try
                {
                    var path = Server.MapPath("/tp");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    foreach (HttpPostedFileBase item in files)
                    {
                        string name = "";
                        
                            Random rd = new Random();
                            string i = rd.Next().ToString();
                            name = i + ".jpg";
                            g.GoodsPic = "tp/" + name;
                
                        item.SaveAs(Path.Combine(path, name));
                    }
                    DateTime sj = DateTime.Now;
                    g.GoodsTime = sj;
                    bool i2 = gs.Add(g);
                    if (i2)
                    {
                        return Content(Ts("添加成功", "../Frontdesk/product_category"));
                    }
                    else
                    {
                        return Content(Ts("添加失败", "../Frontdesk/AddPro"));
                    }

                }
                catch (Exception ex)
                {
                    return Content(string.Format("上传文件出现异常：{0}", ex.Message));
                }
            }
            else
            {
                    return Content(Ts("请选择图片", "../Frontdesk/AddPro"));
            }
        
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public ActionResult DelectGoods(Goods g) {
          bool i=  gs.Delete(g);
            if (i)
            {
                return Content(Ts("删除成功", "../Frontdesk/product_category"));
            }
            else
            {
                return Content(Ts("删除失败", "../Frontdesk/product_category"));
            }
           
        }

        /// <summary>
        /// 留言管理
        /// </summary>
        /// <returns></returns>
        public ActionResult feedback_list()
        {
           ViewData.Model= es.Select();
            return View();
        }

        /// <summary>
        /// 留言回复显示
        /// </summary>
        /// <returns></returns>
        public ActionResult ComeBack(Evaluation e)
        {
            List<Evaluation> list = new List<Evaluation>();
            list.Add(e);
            ViewData.Model = list;
            return View();
        }

        /// <summary>
        /// 留言回复
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public ActionResult UpdateComeBack(Evaluation e) {
           bool i= es.Update(e);
            if (i)
            {
                return Content(Ts("回复成功！", "../Frontdesk/feedback_list"));
            }
            else {
                return Content(Ts("回复失败！", "../Frontdesk/feedback_list"));
            }
         
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public ActionResult DeleBack(Evaluation e)
        {
           bool i= es.Delete(e);
            if (i)
            {
                return Content(Ts("删除成功！", "../Frontdesk/feedback_list"));
            }
            else
            {
                return Content(Ts("删除失败！", "../Frontdesk/feedback_list"));
            }
        
        }

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult member_list()
        {
            ViewData.Model= us.select();
            return View();
        }

        /// <summary>
        /// 修改用户查询绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateMember(User u)
        {
          List<User> list= us.SelectBy(u.UserID);
            ViewData.Model = list;
            return View();
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Updademeberlist(User u) {
           bool i= us.Update(u);
            if (i)
            {
                return Content(Ts("修改成功！", "../Frontdesk/member_list"));
            }
            else
            {
                return Content(Ts("修改失败！", "../Frontdesk/member_list"));
            }
           
        }

        /// <summary>
        /// 新增用户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult member_Add()
        {
            return View();
        }

        /// <summary>
        /// 新增用户操作
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ActionResult memberAdd(User u) {
          bool i= us.Add(u);
            if (i)
            {
                return Content(Ts("新增成功！", "../Frontdesk/member_list"));
            }
            else
            {
                return Content(Ts("新增失败！", "../Frontdesk/member_Add"));
            }
           
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ActionResult memberDele(User u) {
          bool i=  us.Delete(u);
            if (i)
            {
                return Content(Ts("删除成功", "../Frontdesk/member_list"));
            }
            else
            {
                return Content(Ts("删除失败", "../Frontdesk/member_list"));
            }
        }

        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult admin_list()
        {
            ViewData.Model = ks.select();
            return View();
        }

        /// <summary>
        /// 显示修改管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAdmin()
        {
            int id=Convert.ToInt32( Request["KID"]);
            ViewData.Model = ks.selesy(id);
            return View();
        }

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult updateGuanliyuan(Keeper kp)
        {
            var pwd = kp.KPwd;
            var jmPWD = JiaMi.PassMD5(pwd);
            kp.KPwd = jmPWD;
            if (ks.Update(kp))
            {
                return Content(Ts("修改成功！", "../Frontdesk/admin_list"));
            }
            else {
                return Content(Ts("修改失败！", "../Frontdesk/admin_list"));
            }
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="kp"></param>
        /// <returns></returns>
        public ActionResult AddGuanliyuan(Keeper kp)
        {
            var pwd = kp.KPwd;
            var jmpwd = JiaMi.PassMD5(pwd);
            kp.KPwd = jmpwd;
            if (ks.Add(kp))
            {
                return Content(Ts("添加成功！", "../Frontdesk/admin_list"));
            }
            else {
                return Content(Ts("添加成功！", "../Frontdesk/admin_list"));
            }
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="kp"></param>
        /// <returns></returns>
        public ActionResult DeleteAdmin(Keeper kp)
        {
            int id = Convert.ToInt32(Request["KID"]);
            kp.KID = id;
            if (ks.Delete(kp))
            {
                return Content(Ts("删除成功！", "../Frontdesk/admin_list"));
            }
            else
            {
                return Content(Ts("删除成功！", "../Frontdesk/admin_list"));
            }
        }

        
    }
}