Ovo su pojednostavljene skripte za Arduino mikrokontrolere.

Namijenjene su za testiranje preko Serial Monitora i nemaju funkcionalnosti 
povezivanja s GPS-om, desktop i web aplikacijom, niti ocitanja infracrvenih senzora.

Komande za pokretanje (1, 2, 3, 4, 0) se mogu slati preko inputa Serial Monitora.
0 - zaustavljanje 
1 - naprijed
2 - nazad
3 - lijevo
4 - desno

Upload programa na odgovarajuci Arduino:
ArduinoControlSimple - Arduino povezan sa prijenosnim ili stolnim racunalom, komande se unose preko Serial Monitora ovog Arduina
LoRaArduinoRobotSimple - Arduino povezan na LoRa Shield, na robotu
MotorArduinoRobotSimple - Arduino povezan s motorima, na robotu   

Nakon uploada, prvo treba prikljuciti Arduino s LoRa modulom na power bank, a zatim ukljuciti napajanje Arduino Duemillanove preko prekidaca.  