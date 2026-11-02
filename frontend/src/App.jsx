import './index.css';
import { useState, useEffect } from "react";


export default function App()
 {
  const [quantidades, setQuantidades] = useState({});
  const [produtos, setProdutos] = useState([]);

  function quantidadeDe(id){
    return quantidades[id] || 0;
}

  useEffect(() => {
    fetch("http://localhost:5222/api/produtos")
      .then((resposta) => resposta.json())
      .then((dados) => setProdutos(dados));
  }, []);

  function aumentar (id) {
    setQuantidades ({...quantidades, [id]: quantidadeDe(id) + 1})
  }

  function diminuir(id) {
    if (quantidadeDe(id) > 0){
      setQuantidades({...quantidades, [id]: quantidadeDe(id) - 1});
    }
  }
  function subtotal(produto) {
    return produto.preco * quantidadeDe(produto.id)
  }
  function totalGeral() {
    let total = 0
    for (const produto of produtos) {
      total = total + subtotal(produto);
    }
    return total;
  }

  return (
    <div className='pagina'>
      <h1 className='boas-vindas'>Bem-vindo à nossa cantina!</h1>    
      
      {produtos.filter((produto) => produto.ativo).map((produto) => (
        <div className='cartao' key={produto.id}>
          <h3>{produto.nome}</h3>

          <p>
            Preço: R$ {produto.preco.toFixed(2).replace(".", ",")}
          </p>
          <p>Quantidade: {quantidadeDe(produto.id)}</p>
          <p>Subtotal:  R$ {subtotal(produto).toFixed(2).replace(".",",")}</p>
          {produto.quantidadeEstoque === 0 && <p>Esgotado</p>}
          
          <button 
          type='button'
          disabled={quantidadeDe(produto.id) >= produto.quantidadeEstoque}
          onClick={() => aumentar(produto.id)}
          >+</button>

          <button
          type='button'
          onClick={() => diminuir(produto.id)}
          >-</button>
          
        </div>
      ))}
      <h2 className='total'>Total: R$ {totalGeral().toFixed(2).replace(".",",")}</h2>  
    </div>
  );
}


