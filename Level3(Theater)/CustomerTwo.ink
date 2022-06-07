-> start

=== start ===
HEY YOU..
  +[Who, me?]
    -> first("YEAH YOU. DO WE HAVE A PROBLEM?")
  +[How can I help you?]
    -> first("YOU CAN HELP ME BY SHUTTING YOUR MOUTH!")

=== first(response) ===
{response}
  +[Excuse me?]
    -> second("I notice you keep staring at me.. TAKE A PICTURE IT WILL LAST LONGER!")

=== second(response) ===
{response}
  +[Okay sir, would you like to buy something now?]
    -> final("Give me a large Fresh Cola while you're at it, you clown..")
  +[I wasn't staring at you..]
    -> final("Don't lie to me, or else I'll come behind that counter and smack you. Now give me a large Fresh Cola.")
  +[Okay, I'm sorry.]
    -> final("You moron. Now give me a large Fresh Cola, NOW!")

=== final(response) ===
{response}
  
-> END