namespace pz_009
{
    internal class Client
    {
        IClientAdapter adapter = new Adapter();

        public void Show(char x) => adapter.ClientChar(x);
        public void Show(double x) => adapter.ClientDouble(x);
        public void Show(int x) => adapter.ClientInt(x);
    }
}
