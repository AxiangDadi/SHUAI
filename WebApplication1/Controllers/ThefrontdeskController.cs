using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using DAL;

namespace WebApplication1.Controllers
{
    public class ThefrontdeskController : Controller
    {

        public UserServices sb { get; set; }
        //public GoodsServices gs { get; set; }
        GoodsServices gs = new GoodsServices();
        TypeServices ts = new TypeServices();
        SizeServices ss = new SizeServices();
        ShoopServices sp = new ShoopServices();
        TypeDAO t = new TypeDAO(); 
        // GET: Thefrontdesk
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult T_Login()
        {
            List<Model.Type> lt = ts.select();
            ViewBag.Lx = lt;
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ActionResult log(User u) {
            int res = (int)sb.Login(u);
            if (res > 0)
            {
                Session["name"] = u.UserName;
                return Content("<script>window.location.href='../Thefrontdesk/Index';</script>");
            }
            else
            {
                return Content("<script>alert('用户名与密码不正确');window.location.href='../Thefrontdesk/T_Login';</script>");
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult account()
        {
            List<Model.Type> lt = ts.select();
            ViewBag.Lx = lt;
            return View();
        }
        /// <summary>
        /// 实现注册
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ActionResult zhuce(User u)
        {

            var pwd = u.UserPwd;
            string pas = JiaMi.PassMD5(pwd);
            u.UserPwd = pas;
           bool b = sb.Add(u);
            if (b == true)
            {
                return View("Index");
            }
            else
            {
                return Content("<script>alert('用户名与密码不正确');window.location.href='../Thefrontdesk/account';</script>");

            }

        }
   
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(Goods g)
        {
            DataTable dtTop = t.selectBytop();
            ViewBag.Lx = dtTop;

            //List<Model.Type> lt = ts.select();
            //ViewBag.Lx = lt;
            
            DataTable dt= gs.SelectByTime();
            ViewData.Model = dt;

            DataTable dt2 = gs.SelectByNum();
            ViewBag.Num= dt2;

            DataTable dt3= gs.SelectByPrice();
            ViewBag.Price = dt3;

            DataTable dt4 = gs.SelectByShow();
            ViewBag.Show = dt4;

            DataTable dt5 = gs.SelectShoes();
            ViewBag.shoes = dt5;

            return View();
        }

        /// <summary>
        /// 购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult checkout()
        {
            List<Model.Type> lt = ts.select();
            ViewBag.Lx = lt; return View();
        }
        /// <summary>
        /// 类型查询及所有商品，根据ID查询相应父类下的商品信息
        /// </summary>
        /// <returns></returns>
        public ActionResult product(Model.Type t)
        {
            List<Model.Type> lt = ts.select();
            ViewBag.Lx = lt;

            int id = t.TypeID;
            if (id == 0)
            {
             List<Goods> lg=  gs.select();
                ViewData.Model = lg;
            }
            else {
                List<Goods> lg = gs.SelectBys(id);
                ViewData.Model = lg;
            }
            return View();
        }
    
        /// <summary>
        /// 商品详情
        /// </summary>
        /// <returns></returns>
        public ActionResult single(Goods g)
        {
            List<Model.Type> lt = ts.select();
            ViewBag.Lx = lt;
            int id =Convert.ToInt32( g.GoodsID);
            List<Goods> l = gs.SelectByDescripy(id);
            ViewData.Model = l;

            int GoodsId = Convert.ToInt32( g.GoodsID);
            DataTable dt6=ss.SelectAll(GoodsId);
            ViewBag.Stock = dt6;

            DataTable dt7 = ss.SelectBySize(GoodsId);
            ViewBag.Size = dt7;

            Size s = new Size();
             DataTable dt8 = ss.SelectBySizeCount(s);
            ViewBag.SizeCount = dt8;
            return View();
        }

        //根据不同的尺码查询不同库存
        public string select(Size s)
        {
            DataTable dt8 = ss.SelectBySizeCount(s);
            int kc = 0;
            foreach (DataRow item in dt8.Rows)
            {
                kc = Convert.ToInt32(item["GoodsCount"]);
            }
            return JsonConvert.SerializeObject(kc);
        }

        public ActionResult AddShop(Shoop p)
        {
          
            if (Session["name"] != null)
            {
                p.UserName = Session["name"].ToString();
               
                bool b = sp.Add(p);
                if (b)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
            else {
                return Content("k");
            }
            
        }

        /// <summary>
        /// 订单
        /// </summary>
        /// <returns></returns>
        public ActionResult order()
        {
            return View();
        }
    }
}