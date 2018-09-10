using DBSession;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EvaluationServices
    {
        DBSessionEvaluation de = new DBSessionEvaluation();

        public List<Evaluation> Select() {
            EvaluationInterface ti = de.CreateEvaluation();
            return ti.Select();
        }


        public bool Update(Evaluation e)
        {
            EvaluationInterface ti = de.CreateEvaluation();
            ti.Update(e);
            return de.SaveChange();
        }


        public bool Delete(Evaluation g)
        {
            EvaluationInterface ti = de.CreateEvaluation();
            ti.Del(g);
            return de.SaveChange();
        }
    }
}
