using P235ClassWork13062023.Exceptions;
using P235ClassWork13062023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235ClassWork13062023.Services
{
    internal class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public List<Book> FindAllBooksByName(string str)
        {
            //List<Book> books = _books.FindAll(b => b.Name.Contains(str));
            return _books.FindAll(b => b.Name.ToLower().Contains(str.ToLower()));
        }

        public void RemoveAllBookByName(string str)
        {
            _books.RemoveAll(b => b.Name.ToLower().Contains(str.ToLower()));
        }

        public List<Book> SearchBooks(string str)
        {
            return _books.FindAll(b => b.Name.ToLower().Contains(str.ToLower()) || 
            b.AuthorName.ToLower().Contains(str.ToLower()) ||
            b.PageCount.ToString().Contains(str.ToLower()));
        }

        public List<Book> FindAllBooksByPageCountRange(int start, int end)
        {
            return _books.FindAll(b=>b.PageCount >= start && b.PageCount <= end);
        }

        public void RemoveByNo(string code)
        {

            Book book = _books.Find(b => b.Code.ToLower() == code.ToLower());

            try
            {
                if (book == null)
                {
                    throw new BookNullException("Yanlis Code");
                }
                else
                {
                    _books.Remove(book);
                }
            }
            catch (BookNullException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finali Isledi");
            }

        }
    }
}
