namespace RefactorThis.Infrastructure
{
	public class BaseRepository
	{
		protected string _strConn;
		public BaseRepository(string strConn)
		{
			_strConn = strConn;
		}
	}
}
