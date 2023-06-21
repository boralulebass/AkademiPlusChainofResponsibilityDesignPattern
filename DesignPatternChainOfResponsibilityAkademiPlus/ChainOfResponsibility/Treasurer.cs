using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context c = new Context();
            if(req.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Gişe Memuru Ali Yıldırım";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye gişe memuru tarafından ödenmiştir.";
                c.Add(customerProcess);
                c.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Gişe Memuru Ali Yıldırım";
                customerProcess.Description = "Müşterinin talep ettiği tutar gişe memuru tarafından ödenemedi, işlem şube müdür yardımcısına aktarıldı.";
                c.Add(customerProcess);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
