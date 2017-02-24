namespace P4.Data
{
    class Symbol
    {
        public string name;
        public Symbol() {
            this.name = "";
        }

        public bool IsTerminal() 
        {
            return (this is Production) == false;
        }
    }
}