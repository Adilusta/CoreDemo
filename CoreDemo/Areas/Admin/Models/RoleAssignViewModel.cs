namespace CoreDemo.Areas.Admin.Models
{
	public class RoleAssignViewModel
	{
		public int RoleID { get; set; }
		public string Name { get; set; }
		
		//Bu rol bu kullanıcıda var mı bilgisini tutucaz.
		public bool Exist  { get; set; }
	}
}
