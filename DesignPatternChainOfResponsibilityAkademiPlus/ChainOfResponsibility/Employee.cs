using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee employee)
        {
            this.NextApprover = employee;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
