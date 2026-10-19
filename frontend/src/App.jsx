import './index.css';
import { useState } from "react";

const produtos = [
  { id: 1, nome: "Coxinha", preco: 5.00 },
  { id: 2, nome: "Coca-Cola", preco: 5.00 },
  { id: 3, nome: "Cachorro Quente", preco: 8.00 },
];

export default function App() {
  const [quantidades, setQuantidades] = useState({1:0, 2:0, 3:0});

  function aumentar (id) {
    setQuantidades ({...quantidades, [id]: quantidades[id] + 1})
  }

  function diminuir(id) {
    if (quantidades[id] > 0){
      setQuantidades({...quantidades, [id]: quantidades[id] - 1});
    }
  }
  function subtotal(produto) {
    return produto.preco * quantidades[produto.id]
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
      
      {produtos.map((produto) => (
        <div className='cartao' key={produto.id}>
          <h3>{produto.nome}</h3>

          <p>
            Preço: R$ {produto.preco.toFixed(2).replace(".", ",")}
          </p>
          <p>Quantidade: {quantidades[produto.id]}</p>
          <p>Subtotal:  R$ {subtotal(produto).toFixed(2).replace(".",",")}</p>
          <button type='button' onClick={() => aumentar(produto.id)}>+</button>

          <button type='button' onClick={() => diminuir(produto.id)}>-</button>
          
        </div>
      ))}
      <h2 className='total'>Total: R$ {totalGeral().toFixed(2).replace(".",",")}</h2>  
    </div>
  );
}


