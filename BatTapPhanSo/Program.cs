using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatTapPhanSo
{
    class Program
    {



        static void Main(string[] args)
        {
            bool KiemTra = false;
            int TuSo1, MauSo1;
            int TuSo2, MauSo2;

            //nêu biến KiemTra = false phân số nhập hợp lệ (mẫu khác 0 và lớn hơn 1, tử lớn hơn 0)
            do
            {
                //nhập thông tin.
                Console.Write("Nhap tu so 1: ");
                TuSo1 = int.Parse(Console.ReadLine());
                Console.Write("Nhap mau so 1: ");
                MauSo1 = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Nhap tu so 2: ");
                TuSo2 = int.Parse(Console.ReadLine());
                Console.Write("Nhap mau so 2: ");
                MauSo2 = int.Parse(Console.ReadLine());

                Console.WriteLine();

                //nếu trường hợp mẫu bằng 0 và tử âm thì nhập lại
                if (MauSo1 == 0 || MauSo2 == 0)
                {
                    Console.WriteLine("Mau so phia khac 0");
                    KiemTra = true;
                }
                else if (TuSo1 < 0 || TuSo2 < 0)
                {
                    Console.WriteLine("Tu so phai lon hon 0");
                    KiemTra = true;
                }
                else if (MauSo1 < 0 || MauSo2 < 0)
                {
                    Console.WriteLine("Mau so phai lon hon 0");
                    KiemTra = true;
                }
                else KiemTra = false;

            } while (KiemTra == true);

            //nhập số mũ
            int SoMu = LaySoMu();
            PhanSo phanso1 = new PhanSo(TuSo1, MauSo1);
            PhanSo phanso2 = new PhanSo(TuSo2, MauSo2);
           
            //in ra kết quả
            Console.WriteLine("Phep cong " + phanso1.Cong(phanso1, phanso2));
            Console.WriteLine("Phep tru " + phanso1.Tru(phanso1, phanso2));
            Console.WriteLine("Phep nhan " + phanso1.Nhan(phanso1, phanso2));
            Console.WriteLine("Phep chia " + phanso1.Chia(phanso1, phanso2));
            Console.WriteLine("Phep lay luy thua\n" + phanso1.LuyThua(phanso1, phanso2, SoMu));

            Console.ReadKey();
        }

        static int LaySoMu() {

            bool KiemTraSoMu = false;//kiểm tra số mũ có lớn hơn 0 hay ko.
            int m;// số mũ

            //nếu biến KiemTraSoMu = false thì thông tin nhập hợp lệ
            //nếu KiemTraSoMu = false thì thông tin nhập ko hợp lệ.
            do
            {
                //nhập số mũ
                Console.WriteLine("Nhap so mu");
                m = int.Parse(Console.ReadLine());

                //nếu trường hợp số mũ âm thì nhập lại 
                if (m < 0)
                {
                    Console.WriteLine("So mu phai lon hon 0");
                    KiemTraSoMu = true;
                }

            } while (KiemTraSoMu == true);

            return m;
        }

    }
}
