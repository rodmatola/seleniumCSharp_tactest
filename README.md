# O problema

O cliente possui uma ferramenta de automoção própria, que não gera relatórios de uma forma compilada com todos os testes. Precisávamos entrar no site do cliente, copiar o conteúdo, colar numa planilha e fazer as estatísticas.

Este programa em Selenium e C# foi uma tentativa de automatizar esse processo. Tentativa porque o projeto foi interrompido antes de finalizar o programa.

Abaixo a descrição dos comentários:

* **ajustar o dia de hoje e ontem**:
Como os relatórios eram diários, esta parte ajusta as variáveis da data para entrar nos seus respectivos campos.

* **verifica se o popup de manutenção está presente**:
Toda segunda-feira o site entrava em manutenção e, somente neste dia, um popup avisando da manutenção aparecia logo após o primeiro login.

* **fazer login**:
O site pedia dois logins seguidos.

* **verifica se o popup de manutenção está presente**:
O popup também aparecia duas vezes...

* **filtrar por nome e data**:
Vários testes eram feitos, então precisávamos filtrar. Sem filto, TODOS apareciam. 

* **limpando e filtrando por label**:
O site guardava os campos preenchidos com a última busca, então precisava limpá-los antes de preencher novamente.

* **expandir a seleção**:
A busca aparecia fechada com todos os testes. É necessário expandir, clicando no +.

Um problema é que vários IDs do site eram dinâmicos, então usei o CSS selector pra contornar isso. Os "endereços" dos botões foram modificados.