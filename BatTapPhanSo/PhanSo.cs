using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatTapPhanSo
{
    class PhanSo
    {
        int TuSo;
        int MauSo;

        public PhanSo()
        {
           TuSo = 0;
           MauSo = 1;
        }

        public PhanSo(int tuSo, int mauSo)
        {
            TuSo = tuSo;
            MauSo = mauSo;
        }

        public string Cong(PhanSo phanSo1, PhanSo phanSo2)
        {
            phanSo1 = RutGonPhanSo(phanSo1);
            phanSo2 = RutGonPhanSo(phanSo2);
            if (phanSo1.MauSo == phanSo2.MauSo)
            {
                int TongTuSo = phanSo1.TuSo + phanSo2.TuSo;
                int MauSo = phanSo1.MauSo;

                return KetQuaPhepTinh(TongTuSo, MauSo);
            }
            else
            {

                int bscnn = BoiSoChungNhoNhat(phanSo1.MauSo, phanSo2.MauSo);
                int ThuaSoChung1 = bscnn / phanSo1.MauSo;
                int ThuaSoChung2 = bscnn / phanSo2.MauSo;
                int TongTuSo = (phanSo1.TuSo * ThuaSoChung1) + (phanSo2.TuSo * ThuaSoChung2);
                return KetQuaPhepTinh(TongTuSo, bscnn);
            }
                


              

        }







            

        public string Tru(PhanSo phanSo1, PhanSo phanSo2)
        {
            //rút gọn phân số 1 và phân số 2 trước khi thực hiện phép trừ.
            phanSo1 = RutGonPhanSo(phanSo1);
            phanSo2 = RutGonPhanSo(phanSo2);

            //trường hợp mẫu số bằng nhau vd: 5/2 và  3/2
            if (phanSo1.MauSo == phanSo2.MauSo)
            {
                //tính hiệu tử sô và giữ nguyên mẫu số.
                int HieuTuSo = phanSo1.TuSo - phanSo2.TuSo;
                int MauSo = phanSo1.MauSo;

                //trả về kết quả phép trừ.
                return KetQuaPhepTinh(HieuTuSo, MauSo);
            }
            else
            {
                int bscnn = BoiSoChungNhoNhat(phanSo1.MauSo, phanSo2.MauSo);
                int Thuasochung1 = bscnn / phanSo1.MauSo;
                int Thuasochung2 = bscnn / phanSo2.MauSo;
                int HieuTuso = (phanSo1.TuSo * Thuasochung1) - (phanSo2.TuSo * Thuasochung2);
                return KetQuaPhepTinh (HieuTuso, bscnn);
            }
        }

        private string KetQuaPhepTinh(int KetQuaTuSo, int MauSo)
        {
            int ucln = UocChungLonNhat(KetQuaTuSo, MauSo);
            if (ucln != -1) {
                int RutGonTuSo = KetQuaTuSo / ucln;
                int RutGonMaSo = MauSo / ucln;

                string KetQua = string.Format("Ket qua: {0}/{1}", RutGonTuSo, RutGonMaSo);

                return KetQua;
            }
            else {
                //nếu kết quả từ số ra = 0 thì trả về kết quả là 0
                //vd 1/2 - 1/2 = 0
                if (KetQuaTuSo == 0) return "Ket qua: 0";
                else
                {
                    //nếu tử số bằng mẫu số thì trả kết quả về bằng 1. Vd 2/2 = 1
                    if (KetQuaTuSo == MauSo) return "Ket qua: 1";
                    else{
                        //nếu từ số khác mẫu số thì trả kết quả về
                        string KetQua = string.Format("Ket qua: {0}/{1}", KetQuaTuSo, MauSo);
                        return KetQua;
                    }
                }
            }
            
        }

        public string Nhan(PhanSo phanSo1, PhanSo phanSo2)
        {
            //rút gọn phân số 1 và phân số 2 trước khi thực hiện phép chia.
            phanSo1 = RutGonPhanSo(phanSo1);
            phanSo2 = RutGonPhanSo(phanSo2);

            int TuSo = phanSo1.TuSo * phanSo2.TuSo;
            int MaSo = phanSo1.MauSo * phanSo2.MauSo;

            return string.Format("Ket qua: {0}/{1}", TuSo, MaSo);
        }

        public string Chia(PhanSo phanSo1, PhanSo phanSo2)
        {
            //rút gọn phân số 1 và phân số 2 trước khi thực hiện phép chia.
            phanSo1 = RutGonPhanSo(phanSo1);
            phanSo2 = RutGonPhanSo(phanSo2);

            int TuSo = phanSo1.TuSo * phanSo2.MauSo;
            int MaSo = phanSo2.TuSo * phanSo1.MauSo;

           
            return string.Format("Ket qua: {0}/{1}", TuSo, MaSo);
        }

        public string LuyThua(PhanSo phanSo1, PhanSo phanSo2, int Mu)
        {
            //rút gọn phân số 1 và phân số 2 trước khi thực hiện lấy lũy thừa.
            phanSo1 = RutGonPhanSo(phanSo1);
            phanSo2 = RutGonPhanSo(phanSo2);

            //hàm Math.Pow là hàm lấy lũy thừa kiểu trả về double, nên ép kiểu về kiều int
            //vd: Math.Pow(2, 3) tức là 2^3

            //lấy lũy thừa phần số 1.
            int LuyThuaTuSo1 = (int)Math.Pow(phanSo1.TuSo, Mu);
            int LuyThuaMauSo1 = (int)Math.Pow(phanSo1.MauSo, Mu);

            //lấy lũy thừa phần số 2.
            int LuyThuaTuSo2 = (int)Math.Pow(phanSo2.TuSo, Mu);
            int LuyThuaMauSo2 = (int)Math.Pow(phanSo2.MauSo, Mu);

            //hiển thị kết quả
            string KetQuaPhanSo1 = string.Format("Luy thua phan so 1: {0}/{1}", LuyThuaTuSo1, LuyThuaMauSo1);
            string KetQuaPhanSo2 = string.Format("Luy thua phan so 2: {0}/{1}", LuyThuaTuSo2, LuyThuaMauSo2);

            //kị tự \n là kí tự xuống dòng mới.
            return KetQuaPhanSo1 + "\n" + KetQuaPhanSo2;
        }


        public int BoiSoChungNhoNhat(int a, int b)
        {
            //bội chung nhỏ nhất nằm trong khoảng max(a, b) <= bcnn <= a*b
            //nên chỉ cần duyệt các giá trị trong khoảng [max(a,b), a*b]   
            for (int i = Math.Max(a, b); i <= (a * b); i++)
            {
                //giá trị đầu tiên chia hết cho cả a, b là bscnn của 2 số a và b
                if (i % a == 0 && i % b == 0)
                {
                    //vì 2 số a và b có đều chia hết cho số i nên bcnn của 2 số a và b là i
                    int bscnn = i;

                    //trả về kết quả bcnn
                    return bscnn;
                }
            }

            //trả về -1 tức là giữa 2 số a và b không có bcnn
            return -1;
        }

        public int UocChungLonNhat(int a, int b)
        {
            int bcnn = BoiSoChungNhoNhat(a, b);
            //bcnn == -1 là ko có bcnn -> nên sẽ ko có ucln giữa 2 số a, b.
            if (bcnn == -1)
            {
                //trả về -1 tức là ko có ucln giữa 2 số a, b
                return -1;
            }
            else {
                //nếu bcnn != -1 tức là có ucln giữa 2 số a và b
                //tính ucln theo công thức ucln = a*b/bcnn(a,b)
                int ucln = (a * b) / bcnn;

                //trả về kết quả ucln.
                return ucln;
            }
          
        }

        public PhanSo RutGonPhanSo(PhanSo phanSo) {
            
            int ucln = UocChungLonNhat(phanSo.TuSo, phanSo.MauSo);
            //nếu ucln = -1 thì giữa từ số và mẫu số ko có ucln.
            //Nếu ucln != -1 thì giữa tử số và mẫu số có ucln.
            if (ucln != -1) {

                //chia cả tử và mẫu cho ucln
                int RutGonTuSo = phanSo.TuSo / ucln;
                int RutGonMauSo = phanSo.MauSo / ucln;

                //trả về phân số mới sau khi rút gọn tử số, mẫu số.
                return new PhanSo(RutGonTuSo, RutGonMauSo);
            }

            //trường hợp ucln = -1 tức là ko có ucln nên trả về phân số cũ.
            return phanSo;
        }
    }
}
