using System.Text;

namespace TestTasks2024
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        private Node<T>? head;

        public MyLinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> cur = head;
            while (cur != null)
            {
                sb.Append($"{cur.Data} ");
                cur = cur.Next;
            }
            Console.WriteLine(sb.ToString());
        }

        public void CloseListForTest()
        {
            Node<T> cur = head;
            cur.Next.Next.Next = cur.Next;
        }

        public bool IsClosed()
        {
            Node<T> slow = head;
            Node<T> fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }
}