namespace OperationXML.Model
{
    public  class BookModel
    {

    
        private string _bookType;
        public string BookType
        {
            get { return _bookType; }
            set { _bookType = value; }

        }

        private int _bookID;
        public int BookID
        {
            get { return _bookID; }
            set { _bookID = value; }
        }


        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }


        private string _bookAuthor;

        public string BookAuthor
        {
            get { return _bookAuthor; }
            set { _bookAuthor = value; }
        }

        private string _bookPrice;

        public string BookPrice
        {
            get { return _bookPrice; }
            set { _bookPrice = value; }
        }

    }
}
