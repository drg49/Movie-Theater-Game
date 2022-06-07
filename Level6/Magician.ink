-> start

=== start ===
...
  +[Why did you just kill that lady!]
    -> one
  +[Who are you?]
    -> two

=== one ===
It was time for her to go to sleep. It is one of my favorite magic tricks I like to call "The Knockout".
  +[Who are you and what are you doing here?]
    -> oneA

=== oneA ===
I am The Magician. I have been watching you your whole life, since you were a child...
  -> oneB

=== oneB ===
I came here today to confront you. It is time I show you a magic trick.
  +[What are you talking about? Get out of here!]
    -> oneC

=== oneC ===
I am going nowhere... I will not leave here until I show you my magic trick. Are you ready?
  +[Yes]
    -> oneD("Follow me...")
  +[No]
    -> oneD("I will not repeat myself. Now follow me...")

=== oneD(response) ===
{response}
-> END

=== two ===
I am The Magician. But some might call me a wanderer, in this empty, pathless universe we call home...
  +[What are you doing here? I am calling the police.]
    -> twoA

=== twoA ===
You will do no such thing. Besides, they won't be able to see me.
  -> twoB

=== twoB ===
I came here to show you a magic trick, I have been waiting to show you this since you were a child...
  -> twoC

=== twoC ===
I like to make people disappear. Anything you thought wasn't possible, I can prove you wrong.
  +[Where did you come from?]
    -> twoD("I came from a planet far away in the universe. Farther than any human can imagine. I have been on Earth for 648 years...")
  +[Please, just get out of here. I don't want any trouble.]
    -> twoD("There will be no trouble, however, you must do what I say or I promise you there will be trouble.")

=== twoD(response) ===
{response}
  +[This can't be real, what do you need from me..?]
    -> twoE

=== twoE ===
I need you to follow me. Now.
  -> END

