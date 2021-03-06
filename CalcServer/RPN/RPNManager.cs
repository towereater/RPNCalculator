
namespace Calculator
{
    public class RPNManager
    {
        // RPN calculator attached to the manager
        private RPN calc;
        public RPN Calculator {
            get { return calc; }
        }

        // Constructs the manager by setting up the calculator
        public RPNManager(int regNum)
        {
            calc = new RPN(regNum);
        }

        // Interprets a string of operations by executing each instruction
        public void Interpret(string code)
        {
            string[] comms = code.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string comm in comms)
                Execute(comm);
        }

        // Runs a command depending on the calculator depending
        // on the string passed
        private void Execute(string comm)
        {
            double value;
            if (double.TryParse(comm, out value)) {
                calc.Enter(value);
            }
            else if (comm == "+") {
                calc.Add();
            }
            else if (comm == "-") {
                calc.Subtract();
            }
            else if (comm == "*") {
                calc.Multiply();
            }
            else if (comm == "/") {
                calc.Divide();
            }
            else {
                throw new ArgumentException($"Cannot execute the command: {comm}");
            }
        }
    }
}