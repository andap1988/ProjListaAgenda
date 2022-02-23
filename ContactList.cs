using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAgenda
{
    internal class ContactList
    {
        public Contact Head { get; set; }
        public Contact Tail { get; set; }

        public ContactList()
        {
            Head = Tail = null;
        }

        public void Push(Contact newContact)
        {

            if (VoidList())
            {
                Head = Tail = newContact;

                Console.WriteLine("\n oooo Inclusao Concluida");
                Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Order(newContact);

                Console.WriteLine("\n oooo Inclusao Concluida");
                Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void Pop()
        {
            if (VoidList())
            {
                Console.WriteLine("\n xxxx Lista de contatos vazia\n");
                Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Contact tempContact;
                string name, choice;
                int option = 0, qtListEquals = 0;

                Console.Write("\n Digite o nome do contato: ");
                name = Console.ReadLine();

                qtListEquals = QuantityEquals(name);

                if (qtListEquals < 1)
                {
                    Console.WriteLine("\n xxxx Nome não encontrado!");
                    Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else if (qtListEquals < 2)
                {
                    tempContact = SearchContact(name);

                    choice = "";
                    option = 0;

                    Console.WriteLine("\n Deseja excluir esse contato?");
                    Console.WriteLine("\n 1 - Sim");
                    Console.WriteLine(" 2 - Nao");
                    Console.Write(" Escolha: ");
                    choice = Console.ReadLine();
                    int.TryParse(choice, out option);

                    if (option == 1)
                    {
                        Remove(tempContact);

                        Console.WriteLine("\n oooo Remocao concluida!");
                        Console.WriteLine("\n oooo Pressione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n xxxx Remocao Cancelada pelo usuario!");
                        Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }
                else if (qtListEquals > 1)
                {
                    StringComparer order = StringComparer.InvariantCultureIgnoreCase;
                    tempContact = Head;

                    Console.Clear();
                    Console.WriteLine("\n oooo Há mais de um contato com o mesmo nome. \n");

                    do
                    {
                        if (order.Compare(tempContact.Name, name) == 0)
                        {
                            Console.WriteLine("\n oooo POSICAO: " + tempContact.ID + "\n");
                            Console.WriteLine(tempContact.ToString());
                        }
                        tempContact = tempContact.Next;
                    } while (tempContact != null);

                    choice = "";
                    option = 0;

                    Console.WriteLine("\n Qual contato gostaria de remover? (digite o numero corresponde a POSICAO que ele se encontra)");
                    Console.Write(" Escolha: ");
                    choice = Console.ReadLine();
                    int.TryParse(choice, out option);

                    tempContact = SearchID(option);
                    Console.Clear();

                    Console.WriteLine("\n ...: Contato Escolhido");
                    Console.WriteLine(tempContact.ToString());

                    choice = "";
                    option = 0;

                    Console.WriteLine("\n Deseja excluir esse contato?");
                    Console.WriteLine("\n 1 - Sim");
                    Console.WriteLine(" 2 - Nao");
                    Console.Write(" Escolha: ");
                    choice = Console.ReadLine();
                    int.TryParse(choice, out option);

                    if (option == 1)
                    {
                        Remove(tempContact);

                        Console.WriteLine("\n oooo Remocao concluida!");
                        Console.WriteLine("\n oooo Pressione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n xxxx Remocao Cancelada pelo usuario!");
                        Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }
            }
        }

        public void Remove(Contact tempContact)
        {
            Contact auxPrincipal = Head.Next, auxPosition = Head;
            int qt = Quantity();

            StringComparer order = StringComparer.InvariantCultureIgnoreCase;

            if (order.Compare(tempContact.Name, Head.Name) == 0)
            {
                Head = tempContact.Next;
                if (Head == null)
                {
                    Tail = null;
                }
            }
            else
            {
                do
                {
                    if (order.Compare(auxPrincipal.Name, tempContact.Name) == 0)
                    {
                        auxPosition.Next = auxPrincipal.Next;

                        if (auxPosition.Next == null)
                        {
                            Tail = auxPosition;
                        }
                    }

                    auxPosition = auxPrincipal;
                    auxPrincipal = auxPrincipal.Next;

                } while (auxPrincipal != null);

                if (Quantity() == 1)
                {
                    Tail = Head;
                }

                auxPrincipal = null;
                auxPosition = null;
            }
        }

        public void Search()
        {
            if (VoidList())
            {
                Console.WriteLine("\n xxxx Lista de contatos vazia\n");
                Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Contact tempContact;
                string name;
                int qtListEquals = 0;

                Console.Write("\n Digite o nome do contato: ");
                name = Console.ReadLine();
                qtListEquals = QuantityEquals(name);

                if (qtListEquals < 1)
                {
                    Console.WriteLine("\n xxxx Nome não encontrado!");
                    Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else if (qtListEquals < 2)
                {
                    tempContact = SearchContact(name);
                    Console.WriteLine("\n Nome: " + tempContact.Name);
                    Console.WriteLine(" E-mail: " + tempContact.Email);
                    Console.WriteLine("\n ...: Telefones: " + tempContact.Telephones.PrintList());
                    Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (qtListEquals > 1)
                {
                    StringComparer order = StringComparer.InvariantCultureIgnoreCase;
                    tempContact = Head;

                    do
                    {
                        if (order.Compare(tempContact.Name, name) == 0)
                        {
                            Console.WriteLine("\n Nome: " + tempContact.Name);
                            Console.WriteLine(" E-mail: " + tempContact.Email);
                            Console.WriteLine("\n ...: Telefones: " + tempContact.Telephones.PrintList());
                            Console.WriteLine("\n oooo Pressione ENTER para continuar...");
                            Console.ReadKey();
                        }
                        tempContact = tempContact.Next;
                    } while (tempContact != null);

                    Console.WriteLine("\n ------------------------------------------ \n");
                    Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void EditContact()
        {
            if (VoidList())
            {
                Console.WriteLine("\n xxxx Lista de contatos vazia\n");
                Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Contact tempContact = null, newContact = null;

                string name, newName, email, newEmail, choice;
                int op = 0, qtListEquals = 0;

                Console.WriteLine("\n Para editar, precisamos do nome ou e-mail do contato.");
                Console.WriteLine("\n 1 - Para procurar pelo NOME");
                Console.WriteLine(" 2 - Para procurar pelo E-MAIL");
                Console.Write("\n Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                if (op == 1)
                {
                    Console.WriteLine("\n ...: Edicao pelo nome do contato");
                    Console.Write("\n Digite o nome do contato: ");
                    name = Console.ReadLine();

                    qtListEquals = QuantityEquals(name);

                    if (qtListEquals < 1)
                    {
                        Console.WriteLine("\n xxxx Nome não encontrado!");
                        Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                    else if (qtListEquals < 2)
                    {
                        tempContact = SearchContact(name);
                    }
                    else if (qtListEquals > 1)
                    {
                        StringComparer order = StringComparer.InvariantCultureIgnoreCase;
                        tempContact = Head;

                        Console.Clear();
                        Console.WriteLine("\n oooo Há mais de um contato com o mesmo nome. \n");

                        do
                        {
                            if (order.Compare(tempContact.Name, name) == 0)
                            {
                                Console.WriteLine("\n oooo POSICAO: " + tempContact.ID + "\n");
                                Console.WriteLine(tempContact.ToString());
                            }
                            tempContact = tempContact.Next;
                        } while (tempContact != null);

                        choice = "";
                        op = 0;

                        Console.WriteLine("\n Qual contato gostaria de editar? (digite o numero corresponde a POSICAO que ele se encontra)");
                        Console.Write(" Escolha: ");
                        choice = Console.ReadLine();
                        int.TryParse(choice, out op);

                        tempContact = SearchID(op);
                        Console.Clear();
                    }

                }
                else if (op == 2)
                {
                    Console.WriteLine("\n ...: Edicao pelo e-mail do contato");
                    Console.Write("\n Digite o e-mail do contato: ");
                    email = Console.ReadLine();
                    tempContact = SearchContact("", email);
                }

                if (tempContact == null)
                {
                    Console.WriteLine("\n xxxx Nome ou e-mail não encontrado!");
                    Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n ...: Dados do contato");
                    Console.WriteLine("\n Nome: " + tempContact.Name);
                    Console.WriteLine(" E-mail: " + tempContact.Email);
                    Console.WriteLine("\n oooo Telefones: " + tempContact.Telephones.PrintList());
                }

                choice = "";
                op = 0;

                Console.WriteLine("\nQual campo gostaria de editar?");
                Console.WriteLine(" 1 - Nome");
                Console.WriteLine(" 2 - E-mail");
                Console.WriteLine(" 3 - Telefones\n");
                Console.Write(" Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out op);

                if (op == 1)
                {
                    Console.WriteLine("\n ...: Edicao do nome");
                    Console.Write("\n Nome atual: " + tempContact.Name + "\n");
                    Console.Write("\n Novo nome: ");
                    newName = Console.ReadLine();

                    newContact = new Contact(newName, tempContact.Email, tempContact.Telephones);
                    Remove(tempContact);
                    Push(newContact);

                    Console.WriteLine("\n oooo Edicao concluida!");
                    Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (op == 2)
                {
                    Console.WriteLine("\n ...: Edicao do e-mail");
                    Console.Write("\n E-mail atual: " + tempContact.Email + "\n");
                    Console.Write("\n Novo e-mail: ");
                    newEmail = Console.ReadLine();

                    newContact = new Contact(tempContact.Name, newEmail, tempContact.Telephones);
                    Remove(tempContact);
                    Push(newContact);

                    Console.WriteLine("\n oooo Edicao concluida!");
                    Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (op == 3)
                {
                    int qt = 0;

                    TelephoneList newTelephoneList = new TelephoneList();
                    newTelephoneList = newTelephoneList.EditTelephone(tempContact.Telephones);

                    tempContact.Telephones = newTelephoneList;

                    qt = tempContact.Telephones.Quantity();

                    if (qt < 1)
                    {
                        choice = "";
                        op = 0;

                        Console.WriteLine("\n xxxx A lista de telefones desse contato ficou vazia.\n");
                        Console.WriteLine(" Voce pode excluir esse contato ou voltar ao menu e deixar a lista de telefones vazia.\n");
                        Console.WriteLine(" 1 - Excluir Contato");
                        Console.WriteLine(" 2 - Menu\n");
                        Console.Write(" Escolha: ");
                        choice = Console.ReadLine();
                        int.TryParse(choice, out op);

                        if (op == 1)
                        {
                            Remove(tempContact);

                            Console.WriteLine("\n oooo Remocao concluida!");
                            Console.WriteLine("\n oooo Pressione ENTER para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (op == 2)
                        {
                            Console.WriteLine("\n oooo Edicao concluida!");
                            Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n oooo Edicao concluida!");
                        Console.WriteLine("\n oooo Pressione ENTER para voltar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("\n xxxx Opcao invalida.");
                    Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public Contact SearchContact(string name = "", string email = "")
        {
            StringComparer order = StringComparer.InvariantCultureIgnoreCase;
            Contact tempContact = Head, find = null;

            if (name != "")
            {
                do
                {
                    if (order.Compare(tempContact.Name, name) == 0)
                    {
                        find = tempContact;
                    }
                    tempContact = tempContact.Next;
                } while (tempContact != null);
            }
            else if (email != "")
            {
                do
                {
                    if (order.Compare(tempContact.Email, email) == 0)
                    {
                        find = tempContact;
                    }
                    tempContact = tempContact.Next;
                } while (tempContact != null);
            }
            return find;
        }

        public int Quantity()
        {
            Contact tempContact = Head;
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
                    tempContact = tempContact.Next;
                } while (tempContact != null);
                return count;
            }
        }

        public void Order(Contact tempContact)
        {
            Contact auxPrincipal = Head, auxPosition = Head;
            int qt = Quantity();

            StringComparer order = StringComparer.InvariantCultureIgnoreCase;

            do
            {
                if (order.Compare(tempContact.Name, Head.Name) <= 0) // no inicio
                {
                    tempContact.Next = Head;
                    Head = tempContact;
                    auxPrincipal = null;
                }
                else if (order.Compare(tempContact.Name, Tail.Name) >= 0) // no fim
                {
                    Tail.Next = tempContact;
                    Tail = tempContact;
                    auxPrincipal = null;
                }
                else
                {
                    if (order.Compare(auxPrincipal.Name, tempContact.Name) <= 0)
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
                        tempContact.Next = auxPrincipal;
                        auxPosition.Next = tempContact;
                        auxPrincipal = null;
                    }
                }
            } while (auxPrincipal != null);

            auxPrincipal = null;
            auxPosition = null;
        }

        public void PrintList()
        {
            if (VoidList())
            {
                Console.WriteLine("\n xxxx Lista de contatos vazia\n");
                Console.WriteLine("\n xxxx Pressione ENTER para voltar ao menu...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n ...: Total de contatos na agenda: " + Quantity() + "\n");
                Contact tempContact = Head;
                do
                {
                    Console.WriteLine(tempContact.ToString());
                    Console.WriteLine(" oooo Pressione ENTER para continuar...\n");
                    Console.ReadKey();
                    tempContact = tempContact.Next;
                } while (tempContact != null);
            }
        }

        public int QuantityEquals(string name)
        {
            Contact auxPrincipal = Head;
            int count = 0;

            do
            {
                if (auxPrincipal.Name == name)
                {
                    count++;
                    auxPrincipal.ID = count;
                }
                auxPrincipal = auxPrincipal.Next;
            } while (auxPrincipal != null);

            return count;
        }

        public void SetID()
        {
            int i = 0;

            Contact tempContact = Head;

            do
            {
                tempContact.ID = -1;
                tempContact.ID = i + 1;
                tempContact = tempContact.Next;
                i++;
            } while (tempContact != null);

        }

        public Contact SearchID(int ID)
        {
            Contact tempContact = Head, find = null;

            do
            {
                if (tempContact.ID == ID)
                {
                    find = tempContact;
                }
                tempContact = tempContact.Next;
            } while (tempContact != null);

            return find;
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
