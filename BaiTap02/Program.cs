using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap02
{
    class Node
    {
        private float info;
        private Node next;

        public Node(float x)
        {
            info = x;
            next = null;
        }

        public float Info
        {
            set { this.info = value; }
            get { return info; }
        }

        public Node Next
        {
            set { this.next = value; }
            get { return next; }
        }
    }
    class SingleLinkList
    {
        private Node Head;
        public SingleLinkList()
        {
            Head = null;
        }

        // Cac thao tac tren danh sach lien ket don
        // Phuong thuc them nut moi vao dau xau
        public void AddHead(float x)
        {
            Node p = new Node(x); // Cap phat nut moi
            p.Next = Head;
            Head = p;
        }

        // Phuong thuc them nut moi vao cuoi xau
        public void AddLast(int x)
        {
            Node p = new Node(x);
            if (Head == null) // Danh sach lien ket rong
            {
                Head = p;
            }
            else
            {
                Node q = Head;
                // Xac dinh nut cuoi xau
                while (q.Next != null)
                {
                    q = q.Next;
                }
                // Moc noi nut moi vao nut cuoi
                q.Next = p;
            }
        }
        // Phuong thuc xoa nut dau xau
        public void DeleteHead()
        {
            if (Head != null)
            {
                Node p = Head;
                Head = Head.Next;
                p.Next = null;
            }
        }
        // Phuong thuc xoa nut cuoi xau
        public void DeleteLast()
        {
            if (Head != null)
            {
                Node p = Head;
                Node q = null; // nut tam de xac dinh nut truoc p
                // Duyet danh sach de tim nut cuoi
                while (p.Next != null)
                {
                    q = p;
                    p = p.Next;
                }
                q.Next = null;
            }
            //Xoa nut p
            
        }
        // Phuong thuc duyet danh sach (Xuat danh sach)
        public void ProcessList()
        {
            Node p = Head;
            while (p != null)
            {
                Console.Write($"{ p.Info }"); // Xuat gia tri cua nut
                p = p.Next;
            }
        }
        //tim max
        public Node findMax()
        {
            Node max = Head;
            Node p = Head.Next;
            while (p!=null)
            {
                if (p.Info > max.Info) 
                {
                    max = p;
                }
                p = p.Next;
            }
            return max;
        }
        //tinh gia tri trung binh
        public float Avg()
        {
            float sum = 0;
            int count = 0;
            Node p = Head;
            while (p != null)
            {
                sum += p.Info;
                count++;
                p = p.Next;
            }
            return sum / count;
        }
        // Phuong thuc xoa nut co gia x
        public void DeleteNode(int x)
        {
            if (Head != null) // Danh sach co phan tu
            {
                Node p = Head;
                Node q = null; // nut tam de xac dinh nut truoc p
                // Duyet danh sach de tim nut co gia tri can xoa
                while (p != null && p.Info != x)
                {
                    q = p;
                    p = p.Next;
                }
                // Xoa nut p
                if (p != null) // Tim thay nut can xoa
                {
                    if (p == Head)
                        DeleteHead();
                    else
                    {
                        q.Next = p.Next;
                        p.Next = null;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkList l = new SingleLinkList();
            NhapDanhSach(l);
            Console.WriteLine("Danh sach vua tao:");
            l.ProcessList();

            Node max = l.findMax();
            Console.WriteLine($"\nNut co gia tri lon nhat: {max.Info}");

            float tbc = l.Avg();
            Console.WriteLine($"\nGia tri trung binh cac nut: {tbc}");
            Console.ReadLine();
        }
        static void NhapDanhSach(SingleLinkList l)
        {
            string chon = "y";
            float x;
            while (chon !="n")
            {
                Console.Write("Nhap gia tri nut:");
                x = float.Parse(Console.ReadLine());
                l.AddHead(x);
                Console.Write("Tiep tuc (y/n)?");
                chon = Console.ReadLine();
            }
        }
    }
}
