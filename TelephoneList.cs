using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAgenda
{
    internal class TelephoneList
    {
        public Telephone Head { get; set; }
        public Telephone Tail { get; set; }

        public TelephoneList()
        {
            Head = Tail = null;
        }

        public void SetID()
        {
            int i = 0;

            Telephone tempTelephone = Head;

            do
            {
                tempTelephone.ID = -1;
                tempTelephone.ID = i + 1;
                tempTelephone = tempTelephone.Next;
                i++;
            } while (tempTelephone != null);

        }

        public void Push(Telephone newTelephone)
        {
            if (VoidList())
            {
                Head = Tail = newTelephone;
            }
            else
            {
                Order(newTelephone);
            }
        }

        public Telephone SearchID(int ID)
        {
            Telephone tempTelephone = Head, find = null;

            do
            {
                if (tempTelephone.ID == ID)
                {
                    find = tempTelephone;
                }
                tempTelephone = tempTelephone.Next;
            } while (tempTelephone != null);

            return find;
        }

        public TelephoneList EditTelephone(TelephoneList telephones)
        {
            int qtTel = telephones.Quantity(), totTel = 0, op = 0;
            string newType, newDDD, newPhone, choice;

            Telephone tempTelephone;
            TelephoneList newTelephones = new TelephoneList();

            if (qtTel < 1)
            {
                choice = "";
                op = 0;
                Console.Clear();
                Console.WriteLine("\n ...: Edicao dos Telefones \n");
                Console.WriteLine("\n xxxx A lista de telefones desse contato está vazia.\n");
                Console.WriteLine("\n Voce pode adicionar telefones ou voltar ao menu principal.");
                Console.WriteLine("\n 1 - Adicionar");
                Console.WriteLine(" 2 - Menu\n");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                if (op == 1)
                {

                    Console.WriteLine("\n Digite os dados do telefone: ");
                    Console.Write("\n Tipo (Celular, Fixo, Comercial, Recado...): ");
                    newType = Console.ReadLine();
                    Console.Write(" DDD: ");
                    newDDD = Console.ReadLine();
                    Console.Write(" Num.: ");
                    newPhone = Console.ReadLine();

                    newTelephones.Push(new Telephone(newType, newDDD, newPhone));

                    return newTelephones;
                }
                else if (op == 2)
                {
                    Console.WriteLine("\n xxxx Acao Cancelada pelo usuario!");
                    Console.WriteLine("\n xxxx Pressione ENTER para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return telephones;
                }
            }

            Console.Clear();
            Console.WriteLine("\n ...: Edicao dos Telefones");
            Console.WriteLine("\n Telefones atuais:\n");
            telephones.SetID();

            for (int i = 0; i < qtTel; i++)
            {
                Console.WriteLine("\n ---------------------");
                Console.WriteLine("\n oooo POSICAO: " + (i + 1));
                tempTelephone = telephones.SearchID(i + 1);
                Console.WriteLine(tempTelephone.ToString());
                totTel++;
            }

            Console.WriteLine("\n Deseja EDITAR ou REMOVER um telefone?");
            Console.WriteLine("\n 1 - Editar");
            Console.WriteLine(" 2 - Remover\n");
            Console.Write(" Escolha: ");
            choice = Console.ReadLine();
            int.TryParse(choice, out op);

            if (op == 1)
            {
                choice = "";
                op = 0;
                Console.WriteLine("\n Qual telefone gostaria de editar? (digite o numero corresponde a POSICAO que ele se encontra)");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                tempTelephone = telephones.SearchID(op);
                Console.Clear();

                Console.WriteLine("\n ...: Telefone Escolhido");
                Console.WriteLine(tempTelephone.ToString());

                if (telephones.Head == telephones.Tail)
                {
                    Console.WriteLine("\n Digite os novos dados do telefone: ");
                    Console.Write("\n Tipo (Celular, Fixo, Comercial, Recado...): ");
                    newType = Console.ReadLine();
                    Console.Write(" DDD: ");
                    newDDD = Console.ReadLine();
                    Console.Write(" Num.: ");
                    newPhone = Console.ReadLine();

                    newTelephones.Push(new Telephone(newType, newDDD, newPhone));
                    return newTelephones;
                }
                else
                {
                    for (int j = 0; j < qtTel; j++)
                    {
                        if ((telephones.SearchID(j + 1).ID) != (tempTelephone.ID))
                        {
                            newTelephones.Push(new Telephone((telephones.SearchID(j + 1).Type), telephones.SearchID(j + 1).DDD, telephones.SearchID(j + 1).Phone));
                        }
                    }

                    Console.WriteLine("\n Digite os novos dados do telefone: ");
                    Console.Write("\n Tipo (Celular, Fixo, Comercial, Recado...): ");
                    newType = Console.ReadLine();
                    Console.Write(" DDD: ");
                    newDDD = Console.ReadLine();
                    Console.Write(" Num.: ");
                    newPhone = Console.ReadLine();

                    newTelephones.Push(new Telephone(newType, newDDD, newPhone));
                    return newTelephones;
                }
            }
            else if (op == 2)
            {
                choice = "";
                op = 0;
                Console.WriteLine("\n Qual telefone gostaria de remover? (digite o numero corresponde a POSICAO que ele se encontra)");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                tempTelephone = telephones.SearchID(op);
                Console.Clear();

                Console.WriteLine("\n ...: Telefone Escolhido");
                Console.WriteLine(tempTelephone.ToString());

                Console.WriteLine("\n Deseja excluir esse telefone?");
                Console.WriteLine("\n 1 - Sim");
                Console.WriteLine(" 2 - Nao\n");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                if (op == 1)
                {
                    for (int j = 0; j < qtTel; j++)
                    {
                        if ((telephones.SearchID(j + 1).ID) != (tempTelephone.ID))
                        {
                            newTelephones.Push(new Telephone((telephones.SearchID(j + 1).Type), telephones.SearchID(j + 1).DDD, telephones.SearchID(j + 1).Phone));
                        }
                    }

                    Console.WriteLine("\n oooo Remocao concluida!");
                    Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    return newTelephones;
                }
                else
                {
                    Console.WriteLine("\n xxxx Remocao Cancelada pelo usuario!");
                    Console.WriteLine("\n xxxx Pressione ENTER para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return telephones;
                }
            }
            return null;
        }

        public int Quantity()
        {
            Telephone tempTelephone = Head;
            int count = 0;

            if (VoidList())
            {
                return count;
            }
            else
            {
                do
                {
                    count++;
                    tempTelephone = tempTelephone.Next;
                } while (tempTelephone != null);
                return count;
            }
        }

        public void Order(Telephone tempTelephone)
        {
            Telephone auxPrincipal = Head, auxPosition = Head;
            int qt = Quantity();

            StringComparer order = StringComparer.InvariantCultureIgnoreCase;

            do
            {
                if (order.Compare(tempTelephone.Type, Head.Type) < 0) // no inicio
                {
                    tempTelephone.Next = Head;
                    Head = tempTelephone;
                    auxPrincipal = null;
                }
                else if (order.Compare(tempTelephone.Type, Tail.Type) > 0) // no fim
                {
                    Tail.Next = tempTelephone;
                    Tail = tempTelephone;
                    auxPrincipal = null;
                }
                else
                {
                    if (order.Compare(auxPrincipal.Type, tempTelephone.Type) < 0)
                    {
                        if (auxPrincipal == auxPosition)
                        {
                            auxPrincipal = auxPrincipal.Next;
                        }
                        else
                        {
                            auxPosition = auxPrincipal;
                            auxPrincipal = auxPrincipal.Next;
                        }
                    }
                    else
                    {
                        tempTelephone.Next = auxPrincipal;
                        auxPosition.Next = tempTelephone;
                        auxPrincipal = null;
                    }
                }
            } while (auxPrincipal != null);
        }

        public string PrintList()
        {
            Telephone tempTel = Head;
            string msg = "";

            if (VoidList())
            {
                msg = msg + "\n xxxx Lista de telefones vazia\n";
            }
            else
            {
                do
                {
                    msg = msg + tempTel.ToString();
                    tempTel = tempTel.Next;
                } while (tempTel != null);
            }

            return msg;
        }

        public bool VoidList()
        {
            if ((Head != null) && (Tail != null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
