using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetList();
        void TalentAddBl(Talent talent);
        Talent GetById(int id);
        void TalentDeleteBl(Talent talent);
        void TalentUpdateBl(Talent talent);
    }
}
