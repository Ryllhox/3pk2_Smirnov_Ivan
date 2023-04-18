namespace pz_009
{
    internal class Adapter : Origin, IClientAdapter
    {
        public void ClientChar(char x)
        {
            for (int i = 0; i < 5; i++) base.OriginChar(x);
        }

        public void ClientDouble(double x)
        {
            base.OriginDouble(x);
        }

        public void ClientInt(int x)
        {
            base.OriginInt(x*2);
        }
    }
}
