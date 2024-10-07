namespace MaxFitGym.Repository
{
    public class MemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
