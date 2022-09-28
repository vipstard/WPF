using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Models
{
    public class Emp
    {
        private int _Empno;
        private string _EName;
        private int _Deptno;

        public int Empno
        {
            get{return _Empno; }
            set { _Empno = value; }
        }

        public string Ename
        {
            get { return _EName; }
            set { _EName = value; }
        }

        public int Deptno
        {
            get { return _Deptno; }
            set { _Deptno = value; }
        }
        public  Emp(int Empno, string Ename, int Deptno)
        {
            this.Empno = Empno;
            this.Ename = Ename;
            this._Deptno = Deptno;
        }
    }
}
