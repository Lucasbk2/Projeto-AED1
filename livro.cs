using System;

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

}
