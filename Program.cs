using System;

namespace ListaAgenda
{
    internal class Program
    {
        public static int Menu()
        {
            bool flag = true;
            string choice;
            int option = 0;

            while (flag)
            {
                Console.WriteLine("\n ...:::: MENU ::::....\n");
                Console.WriteLine(" 1 - Inserir Contato");
                Console.WriteLine(" 2 - Localizar Contato");
                Console.WriteLine(" 3 - Remover Contato");
                Console.WriteLine(" 4 - Editar Contato");
                Console.WriteLine(" 5 - Imprimir Agenda");
                Console.WriteLine(" 6 - Sair\n");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out option);

                if ((option < 1) || (option > 6))
                {
                    Console.WriteLine("\n xxxxx Opcao invalida.");
                    Console.WriteLine("\n xxxxx Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    flag = false;
                }
            }
            return option;
        }

        public static Contact InsertContact()
        {
            TelephoneList MyTelephoneList = new TelephoneList();
            string choice;

            Console.WriteLine("\n ...: Novo Contato\n");
            Console.Write(" Nome: ");
            string name = Console.ReadLine();
            Console.Write(" E-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("\n ...: Telefones");

            Console.WriteLine("\n xxxx Caso nao queira atribuir um telefone nesse contato, basta deixar todos os campos vazios.\n");

            Console.Write("\n Tipo :");
            string typeTel = Console.ReadLine();
            Console.Write(" DDD: ");
            string dddTel = Console.ReadLine();
            Console.Write(" Num.: ");
            string phoneTel = Console.ReadLine();
            MyTelephoneList.Push(new Telephone(typeTel, dddTel, phoneTel));

            Console.Clear();
            do
            {
                Console.WriteLine("\n Deseja incluir mais um telefone?");
                Console.WriteLine(" 1 - Sim");
                Console.WriteLine(" 2 - Nao");
                Console.Write("\n Escolha: ");
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.Write("\n Tipo: ");
                        typeTel = Console.ReadLine();
                        Console.Write(" DDD: ");
                        dddTel = Console.ReadLine();
                        Console.Write(" Num.: ");
                        phoneTel = Console.ReadLine();
                        MyTelephoneList.Push(new Telephone(typeTel, dddTel, phoneTel));
                        Console.Clear();
                        break;

                    case "2":
                        break;

                    default:
                        Console.WriteLine("\n xxxxx Opcao invalida. Tente novamente.");
                        break;
                }
            } while (choice != "2");
            return new Contact(name, email, MyTelephoneList);
        }

        static void Main(string[] args)
        {
            ContactList MyContactList = new ContactList();

            bool flag = true;
            int option;

            option = Menu();

            while (flag)
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n ..:: Cadastrar Contato\n");
                        MyContactList.Push(InsertContact());
                        option = Menu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n ..:: Localizar Contato\n");
                        MyContactList.Search();
                        option = Menu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n ..:: Remover Contato\n");
                        MyContactList.Pop();
                        option = Menu();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n ..:: Editar Contato\n");
                        MyContactList.EditContact();
                        option = Menu();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("\n ..:: Imprimir Agenda\n");
                        MyContactList.PrintList();
                        Console.Clear();
                        option = Menu();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("\n xxxxxxxxx OBRIGADO POR USAR NOSSO SISTEMA xxxxxxxx \n");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Opção invalida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
