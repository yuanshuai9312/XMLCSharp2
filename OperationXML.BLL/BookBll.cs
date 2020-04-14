using OperationXML.DAL;
using OperationXML.Model;
using System.Collections.Generic;
using System.Data;
namespace OperationXML.BLL
{
    public class BookBll
    {
        BookModel _person= new BookModel();
        BookDal _a = new BookDal();

        public DataSet PersonLoad()
        {
            DataSet ds = _a.LoadBookInfo();
            return ds;

        }          //加载

        public void Creat(BookModel  n)
        {
            _a.CreatBookInfo(n);
        }   //创建

        public void Add(BookModel m)
        {

            _a.AddBookInfo(m);

        }      //添加

        public void Delete(string  _bookmodel)
        {
           
            _a.DeleteBookInfo(_bookmodel);
        }   //删除

        public void Update(BookModel d)
        {

            _a.UpdateBookInfo(d);

        }           //更改

        public List<BookModel> Query( int intFalg,string c)
        {
            List<BookModel> list = new List<BookModel>();
          list = _a.QueryBookInfo(intFalg,c);
            return list;
        }   //查询
    }
}
