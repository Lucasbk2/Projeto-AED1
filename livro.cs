using System;
using System.IO;
using System.Text;

class Livro{

	//Declaração dos Atributos
	private string nome;
	private string genero;
	private string autor;
	private int faixa_etaria;

	//Construtores
	public Livro(string n, string g, string a, int f){
		this.nome = n;
		this.genero = g;
		this.autor = a;
		this.faixa_etaria = f;
	}

	public Livro(){
		this.nome = "";
		this.genero = "";
		this.autor = "";
		this.faixa_etaria = 0;
	}

	//Métodos get/set
	public string getNome(){
		return nome;
	}

	public void setNome(string n){
		nome = n;
	}


	public string getGenero(){
		return genero;
	}
	public void setGenero(string g){
		genero = g;
	}


	public string getAutor(){
		return autor;
	}
	public void setAutor(string a){
		autor = a;
	}
	

	public int getFaixa_etaria(){
		return faixa_etaria;
	}
	public void setFaixa_etaria(int f){
		faixa_etaria = f;
	}
	
	//Métodos Funcionais
	public string AlterarFaixaEtaria(int idade){
		faixa_etaria = idade; 
		return "Faixa Etária alterada com sucesso";

	}

	public bool VerificarClassificacao(int idade){
		if (idade >= faixa_etaria){
			return true;
		}
		return false;
	}

	public void MostrarLivros(){

		FileStream leituraArquivo = new FileStream("dadosLivro.txt",FileMode.Open,FileAccess.Read);		
		StreamReader sr = new StreamReader(leituraArquivo,Encoding.UTF8);
		
		while(!sr.EndOfStream){
			string str = sr.ReadLine();			
			Console.WriteLine(str);
		}
		sr.Close();
		leituraArquivo.Close();
	}
	
	public void MostrarDescricao(string nomeLivro, Biblioteca biblio){
		Console.WriteLine("---------------------------------------");
		Console.WriteLine("----------Descrição do Livro-----------");
		Console.WriteLine("| Nome : "+nome);
		Console.WriteLine("| Gênero: "+genero);
		Console.WriteLine("| Autor: "+autor);
		Console.WriteLine("| Faixa Etária: "+faixa_etaria);
		Console.WriteLine("---------------------------------------");

	}

}
