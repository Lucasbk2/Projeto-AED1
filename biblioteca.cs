using System;
class Biblioteca{
	
//Declaração dos Atributos
	private string nome;
	private string cep;
	private Usuario[] usuarios = new Usuario[50];
	private Livro[] livros = new Livro [50];
	
//Construtores
	public Biblioteca(string n, string c){
		this.nome = n;
		this.cep = c;
	}
	public Biblioteca(){
		this.nome = "";
		this.cep = "";
	}
//Métodos get/set
	public string getNome(){
		return nome;
	}
	public void setNome(string n){
		nome = n;
	}
	public void setUsuario(Usuario user){
		usuarios[0] = user;
	}

	public string getCep(){
		return cep;
	}
	public void setCep(string c){
		cep = c;
	}
	//Métodos Funcionais
	public void RealizarCadastro(Usuario user){
		for(int x=0;x < usuarios.Length;x++){
			if(usuarios[x] == null){
				usuarios[x] = user;
				Console.WriteLine("Adicionou");
				break;
			}
			
		}
	}
		public bool AutentificarUsuario(string nome){	

			for(int x=0; x< usuarios.Length;x++){
				if(usuarios[x].getNome() == nome){
					return true;
			}
			}
			
		return false;

		
		}
}