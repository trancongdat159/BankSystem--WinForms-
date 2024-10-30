namespace Banking.Model
{
    internal class BranchModel : IModel
    {
        public  string id {  get; set; }
        public string name { get; set; }
        public string house_no {  get; set; }
        public string city { get; set; }

        //public BranchModel (string id, string password, string house_no)
        //{
        //    this.id = id;
        //    this.name = password;
        //    this.house_no = house_no;
        //    this.city = city;
        //}

        //// Parameterless constructor
        //public BranchModel() { }

    }
}
