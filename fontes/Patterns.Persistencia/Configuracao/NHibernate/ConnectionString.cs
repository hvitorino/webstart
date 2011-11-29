namespace Patterns.Persistencia.Configuracao.NHibernate
{
	public class ConnectionString
	{
		private static readonly ConnectionString Instance = new ConnectionString();

		public static ConnectionString Value
		{
			get { return Instance; }
		}

		private string value;

		public void Set(string newValue)
		{
			value = newValue;
		}

		public string Current { get { return value; } }
	}
}