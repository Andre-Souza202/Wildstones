INCLUDE globals.ink

VAR Trust = 0
VAR PoucoConvencido = false

-> main

===main===

A cada passo mais próximo da cabana, mais altos podem ser ouvidos os gritos de discussão.

Seu coração bate com ansiedade, mas você está aqui por uma missão, é agora ou nunca…

NÃO! Tentar sair nadando dessa ilha é uma péssima ideia! #character:character #name:Kerak

Você encontra Kerak no meio da cabana, ele não parece estar bem humorado, mas não demora muito até que sua presença deixe de ser um segredo, e Kerak fixa os olhos em você. #character:null #name: 

Estamos ocupados. #character:character #name:Kerak

* [Tenho uma ideia melhor do que sair nadando da ilha]

    Oh? Por acaso seria voando? Não temos tempo para ideias bobas.

    * * [E qual é a sua ideia então?]

        Se você não faz parte da discussão, acho melhor se retirar.

        -> GramurIntervem

    * * [Ei, eu estou tentando ajudar aqui!]

        Não me leve a mal, mas acho que essa não é uma questão que cidadãos comuns deveriam se intrometer, pode deixar que nós estamos resolvendo o problema.

        * * * {FalouIsac == true} [Isac, me ajuda aqui!]
        
        -> ajudaIsac

        * * * [Mas…]
        
        ->GramurIntervem

    * * [Devemos unir os clãs para resolvermos esse problema]
    
    -> apresentar

* [Estou aqui para ajudar a resolver a situação]

    Não me leve a mal, mas essa não é uma questão para cidadãos comuns, pode deixar que estamos resolvendo o problema.

    * * [Devemos unir os clãs para resolvermos esse problema]
    
    -> apresentar

    * * [Você não vai nem me ouvir?]

        Essa é uma questão delicada, como disse, pode deixar que estamos resolvendo a situação.
        
        -> GramurIntervem

    * * {FalouIsac == true} [Isac, me ajuda aqui!]
    
    ->ajudaIsac

* {FalouIsac == true} [Isac deve ter avisado que eu viria]

->IsacApresentou


===GramurIntervem===
~ Trust -= 2
Kerak, esse é Pierre, ele me ajuda com o transporte dos minérios, é uma boa pessoa. Se ele tem algo importante a dizer, acho que devemos pelo menos ouvi-lo #name:Gramur #trust:-2

Muito bem, eu confio em seu julgamento Gramur. Mas Pierre, seja mais direto da próxima vez, não gosto de respondões. #name:Kerak

* [Devemos unir os clãs para resolvermos esse problema]

-> apresentar


===ajudaIsac===
~ Trust -= 1
O quê? Eu… eu… #name:Isac #trust:-1
-> IsacApresentou


===IsacApresentou===
~ Trust += 2
Ah! Então é você quem teve a ideia de que devemos contatar os outros clãs de que Isac comentou #name:Kerak #trust:2

Kerak olha para Isac, dá para perceber que ele não deve ter gostado muito da ideia. #character:null #name: 

Conversamos um pouco sobre ela, mas do que eles nos serviriam? Estamos melhor por conta própria.#character:character #name:Kerak

->apresentar2


//TERMINARRRRRRRRRRRRRRRRRRR
//TERMINARRRRRRRRRRRRRRRRRRR
//TERMINARRRRRRRRRRRRRRRRRRR
//Reutilizar bastante parte do dialogo do ===apresentar== mas levando em conta que Kerak já pensou sobre o assunto antes

->END

===apresentar===
{FalouIsac == true:
-> IsacApresentou
}

Unir os clãs? Hahahahaha não me faça rir, você deve saber que isso seria uma tarefa impossível. #name:Kerak

E mesmo se desse em algo, do que nos serviria? Estamos melhor por conta própria.

-> apresentar2

===apresentar2===

* {FalouRose == true} [Acho que deve se lembrar de Rose, eles não são tão ruins]

    ~ Trust += 2
    …

    Eu me lembro… de que os Rubi salvaram a Rose antes de chegarmos.

    * * [Vê? Eles não são tão ruins quanto pensa]
    
        Como pode ter tanta certeza?
    
    -> apresentar2

* [Não vamos conseguir resolver por conta própria] 

    E o que diz que eles não vão mais atrapalhar do que ajudar?

    * * [E por que eles atrapalhariam?]
    
        A muitos anos atrás, meu pai me contou um acontecimento que fechou uma de nossas minas, e foi tudo por causa desses outros clãs idiotas, arriscando a vida dos nossos para roubarem os minérios para si, o que dirá que não vão querer se aproveitar de novo?
        
        * * * {SabeGrandeRavina == true} [Dramelio me contou sobre o acontecimento da Grande Ravina...]
            
            Dramelio? Lembro desse nome, suponho que seja o nosso minerador que ficou preso naquele dia.
            
            * * * * [Ele disse que todos se ajudaram, e que as acusações não passam de um mal entedido]
    
            ~ Trust += 2
            Mas meu pai… Suponho que eu deva averiguar as informações eu mesmo, depois converso com Dramelio sobre o que aconteceu aquele dia. #trust:2
         
            -> apresentado
        
        * * * [Mas todos estão em risco!]
        
            ~ Trust -= 1
            E não é por isso que devemos confiar em qualquer um. #trust:-1
            
            Mas já passou tanto tempo… assim como você está no lugar de seu pai, os líderes dos outros clãs também são pessoas diferentes, talvez as coisas estejam diferentes? #name:Gramur
            
            -> diferencasLado
        
     * * [Eles não são tão ruins quanto pensa]
    
        E você já chegou a conversar com algum deles?

        * * * {FalouClotilde == true} [Não, mas Clotilde sim, ela me contou que eles são boas pessoas!]

            ~ Trust += 1

            Eles não são tão bons quanto você pensa, histórias são diferentes de convivência. #trust:1
            
            -> diferencasLado

        * * * [Não…]

            Você não sabe o que temos que passar quando precisamos interagir com seus líderes, lidar sempre com tons de acusação, olhares de desprezos, sempre com algo para reclamar, não que sejamos tão diferentes nesses quesitos, eles gostam de nos importunar quando podem.
            
            -> diferencasLado

//TERMINARRRRRRRRRRRRRRRRRRR
//TERMINARRRRRRRRRRRRRRRRRRR
//TERMINARRRRRRRRRRRRRRRRRRR

//* [Definitivamente podemos usar mais cabeças para pensar e trabalhar]

//    Você não está errado, mas precisamos das cabeças certas, se não só vão atrapalhar
    
//    * * [f]
//    ->END
    
//    * * [f]
//    ->END
    
===diferencasLado===
* [Devemos deixar nossas diferenças de lado]
        
    Anos de conflitos não são tão fáceis de esquecer. #name:Kerak
        
    * * [Nunca vamos fazer as pazes se não dermos o primeiro passo]
        
        ~ Trust += 1
        Eu concordo com Pierre #name:Dramur #trust:1
        
        -> apresentado
            
    * * [Devemos pelo menos tentar]
        
    
    {Trust >= 3}    
        
    ~ Trust -= 1
    Me parece que se tornaria apenas uma perda de tempo, e tempo é bem valioso. #trust:-1
        
    -> apresentado
        
//* [Todos estamos em risco, eles não têm escolha senão ajudar]

//E como eles ajudariam a parar o vulcão? O que eles podem fazer que nós já não possamos?
        
//    * * [Não sei, e é exatamente por isso que devemos buscar ajuda]
    
    
    
 //   * * [Não sei, mas sei que sozinhos não vamos conseguir fazer nada]
            
            
                
   //     -> apresentado
            
   // * * [Devemos pelo menos tentar]
            
   //     ~ Trust -= 1
   //     Me parece que se tornaria apenas uma perda de tempo, e tempo é bem valioso. #trust:-1
                
   //     -> apresentado

===apresentado===

. . . #name:Kerak

Mas tudo bem, supomos que eles sejam “Uma ajuda valiosa”, como os convenceriamos? Eles não gostam de nós tanto quanto não gostamos deles.  #name:Kerak

{Trust < 3 }

Kerak olha em volta para cada integrante do Conselho antes de continuar. #character:null #name: 

Entre nós, poucos são os que sabem falar suas línguas, e os que sabem não teriam cabeça para conversar com eles, isso me incluindo. #character:character #name:Kerak

Sem um diplomata não vamos conseguir nem chegar a conversar com seus líderes.

* [Eu posso fazer esse papel]

Kerak olha para você de forma suspeita, não sabendo se está brincando ou não. #character:null #name: 

* * [Eu conheço a lingua dos outros clãs]

Isso já estava na sua mente quando chegou aqui não é? #character:character #name:Kerak

Tudo bem, mas antes... Vamos ver se você realmente está pronto para o trabalho.

Vou te perguntar um termo mais obscuro dos Lápis Lazuli, e você deve me dizer uma palavra equivalente que se aproxime de seu significado.

Algo que é desejado, mas que não temos a vista nesse momento, o que significa <color=\#fc0000>kidrodrum</color>?
* * * [Esperança]

Enquanto estivermos de pé, não perderemos a esperança. Infelizmente esse não é o seu siginificado. #trust:-1

->acabar

* * * [Sorte e prosperidade]

Você acertou, talvez consiga mesmo seguir com seu plano. #trust:+1

Eu vou confiar em você, não acho que temos nada a perder

Va descansar por essa noite, amanhã você sera enviado para os clãs Lapis Lazuli e Ruby.

->acabar

* * * [Futuro e oportunidades]

Nosso futuro não está claro. Infelizmente esse não é o seu significado. #trust:-1

->acabar

* * * [Liberdade]

Estamos presos nessa situação e nessa ilha. Mas infelizmente esse não é o seu siginificado da palavra. #trust:-1

->acabar

===acabar===

Você pode ter errado, mas gosto da sua atitude, eu suponho que não temos nada a perder por tentar.

Va descansar por essa noite, amanhã você sera enviado para os clãs Lapis Lazuli e Ruby.

-> END