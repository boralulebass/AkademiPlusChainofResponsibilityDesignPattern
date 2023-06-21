using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context c = new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı Zeynep Çiçek";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye şube müdür yardımcısı tarafından ödenmiştir.";
                c.Add(customerProcess);
                c.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı Zeynep Çiçek";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdür yardımcısı tarafından ödenemedi, işlem şube müdürüne aktarıldı.";
                c.Add(customerProcess);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
