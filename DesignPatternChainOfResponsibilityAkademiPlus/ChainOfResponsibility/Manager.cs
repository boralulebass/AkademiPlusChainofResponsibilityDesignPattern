using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context c = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdürü Hakan Kayalı";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye şube müdürü tarafından ödenmiştir.";
                c.Add(customerProcess);
                c.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdürü Hakan Kayalı";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdürü tarafından ödenemedi, işlem bölge müdürüne aktarıldı.";
                c.Add(customerProcess);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
