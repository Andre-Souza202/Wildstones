INCLUDE globals.ink

{
-SabeAgua == false:
->main
- SabeAgua == true:
->revisita
- else:
->finalisado
}
-> main

=== main ===
Oi Pierre, estou um pouco nervosa com o que está acontecendo, sabe, esse papo todo do vulcão e... #name:Clotilde #character:character


Eu não acho que estou muito bem, você teria um pouco de água para mim por favor? 

~ SabeAgua = true

* [Fique tranquila, vamos resolver isso]

Fique tranquila, fique tranquila... Tudo bem, mas esta situação ainda é muito estressante, mas vou tentar me manter calma, mas se você encontrar água, por favor me ajudaria muito.
->END
    
* {PegouAgua == false} [Não tenho água comigo, mas posso tentar conseguir para você]

Por favor, estarei esperando.
->END

* {PegouAgua == true} [Sim, eu tenho água aqui comigo]

->kidrodrum

=== kidrodrum ===

~ EntregouAgua = true

Muito obrigada, acho que já estou me sentindo melhor, <color=\#fc0000>kidrodrum</color> Pierre! #word:0

* [Kidro... o que?]

Haha me desculpe, é um termo da lingua do clã Lápis Lazúli, ele significa sorte e prosperidade, então eu te desejei sorte em seu caminho.

    * * [Você conhece a língua dos Lapis Lazuli?]
        
        ~ FalouClotilde = true
        Sim, na verdade, eu já os visitei! São pessoas bem agradaveis, e bem engenhosos, ao contrario do que é espalhado por ai... huff como eu gostaria que não tivessem tantos conflitos entre nós.
        
            * * * [Eu acredito que os clãs possam se entender, estou indo falar com Kerak sobre isso]
            
            Serio? Isso seria ótimo! Me sinto menos nervosa sabendo que vocês vão resolver a situação, muito obrigada.
        
            ->END

    * * [Obrigado! Até mais]

    ->END

* [Até mais]

->END

=== revisita ===
{EntregouAgua == true: ->finalisado}

Oi de novo Pierre, conseguiu água para mim? #name:Clotilde #character:character

* {PegouAgua == false} [Ainda não]
Tudo bem, estarei aqui esperando
->END

* {PegouAgua == true} [Sim, aqui está]
-> kidrodrum

=== finalisado ===
Já estou me sentindo melhor graças a sua ajuda Pierre. #name:Clotilde #character:character
->END