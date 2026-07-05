**[00:18] coolcamilla:** Overall, what did we accomplish this week? This week, we tried to focus on responding to your feedback. So here’s everything we...

**[00:27] Customer:** Please tell me how it went.

**[00:29] coolcamilla:** Yeah, we managed to do it. Well, I think it turned out pretty well-yeah, not bad. I mean, basically, we worked on what you told us to do: simplify the inventory, so we simplified it. Make a slight change to the climbing mechanics-we did that. There you go. Also, it turns out we’ve changed the crafting system. Now you can’t craft multiple tools at once. Well, at any given time, you can only hold one. It’s like in Forger-basically, there’s a slot displayed at the bottom. Our inventory now… Well, it’s not visible all the time-only when you open it.

**[01:05] Customer:** Cool. How’s it going with the game designer?

**[01:08] WazzuRunaway:** We don’t know…

**[01:10] coolcamilla:** Well, nothing really new has been added yet, but we thought-I mean, we’re going to be making improvements to the mole anyway-so I thought a little bit about what interesting mechanics we could add for him. I’ll tell you about that. Well, that’ll be a little later, I guess. There you go. Oh, and we fixed some bugs-the mole doesn’t fly anymore, unfortunately.

**[01:36] Customer:** Guys, please generate a normal interface. I’m begging you. Ask… Give ChatGPT a prompt on how to make an interface. Well, yeah… Oh well. Let the mole who’s doing this just do it.

**[01:48] coolcamilla:** Yeah, that’s okay. There you go. Well, and we were also, unfortunately, working on documentation and architectural documentation. SunrisEe41 will talk about that.

**[02:04] SunrisEe41:** Right now?

**[02:05] coolcamilla:** No, no, not now, later. Not right now. I can also show you-just in case you’re interested-what we’ve been up to this week, basically what we’ve been working on.

**[02:16] Customer:** I want to… say something, chat a bit. The concept doc… I definitely want to chat.

**[02:26] coolcamilla:** Well, we’ve actually done some work on it, but we just haven’t uploaded it to GitHub yet.

**[02:32] Customer:** It’s cool that you’re sharing videos. Are those your requirements?

**[02:38] coolcamilla:** Yeah. Well, not about the videos-I just added that part as a joke.

**[03:01] Customer:** There are, right? There are, there are, okay. What’s there? (laughs).

**[03:17] Customer:** New sprites? New sprites!

**[03:19] coolcamilla:** Yeah, there are sprites.

**[03:21] Customer:** It... it might even be awesome.

**[03:24] coolcamilla:** God willing.

**[03:25] Customer:** God willing, yeah. But God usually doesn’t give us cool stuff.

### UAT session starts

**[03:30] coolcamilla:** Okay. So now, according to the plan… And now we have this… we’ll just dive right in, basically. Let’s start this… Anyway, first, I think we can check the bugs to see how they’ve changed. It’s like he’s digging.

**[04:17] Customer:** Save me, save me. Where am I? Why is this world blue?

**[04:30] coolcamilla:** Let’s check the bugs first.

**[04:37] Customer:** Oh, so you only have the drill when I... Oh... Right. You only have the drill when I get to the pickaxe, right?

**[04:47] coolcamilla:** Well, yeah, it’s just there...

**[04:50] WazzuRunaway:** On that note, we’d like to add branching paths later-different tool subtypes.

**[04:58] Customer:** Cool, that’s a great idea. Good job, guys.

**[04:58] WazzuRunaway:** For now, it goes from wood to stone. So the stone one isn’t implemented yet.

**[05:01] Customer:** Okay. Just identify... And it would be good to add question marks-it would be great to... Highlight... The unknown, guys, the unknown. What’s behind the interface? What’s... Ooh! Ooh! The unknown.

**[05:27] Customer:** We need to revamp the interface. Go back to ChatGPT, type in, “I have this reference-please make it work properly.” Show me how to arrange the objects here. Or, you know… Do some research and see how others did it. But that takes so much time…

**[05:43] coolcamilla:** Don’t dig yet! Don’t dig! No! We need to check for bugs first!

**[05:50] Customer:** Which ones?

**[05:51] coolcamilla:** Just go up to any wall-left or right, it doesn’t matter… Oh, no, let’s do this first. Oops, let’s check the bugs first.

**[06:03] Customer:** Go up to the wall first, right?

**[06:08] coolcamilla:** Yeah.

**[06:14] SunrisEe41:** That’s parkour.

**[06:18] WazzuRunaway:** We left that on purpose, right? Because it looks really cool when he runs up them like stairs, I thought.

**[06:24] Customer:** Hmm, no, that’s cool, but the player doesn’t recognize it. So we need to indicate it somehow. Like, the corner of the block should be visually highlighted. Otherwise, it seems like… Now just press the spacebar a bunch of times in a row. Fixed it.

**[07:07] Customer:** No, well, that’s ridiculous.

**[07:17] SunrisEe41:** We haven’t described yet, yeah, how the new climbing system works in general.

**[07:21] coolcamilla:** Ah... Well, overall, it’s already like that, yeah... Anyway, and now, can you exit climbing mode?

**[07:31] Customer:** Right now.

**[07:34] SunrisEe41:** It climbs slowly when stamina...

**[07:37] coolcamilla:** Oh, so you press Escape to pause. Now press the spacebar a bunch of times... And unpause.

**[07:47] Customer:** He didn’t take off! He didn’t take off! You guys are so great!

**[07:52] coolcamilla:** All done. Okay. Well, that’s normal for a bug-basically, everything’s working. Now, about this… the climbing. We need to dig a hole... Well, actually, we don’t really need to dig one-it’s already here.

**[08:08] Customer:** What, 3 by 3? 4 by 4? How big?

**[08:12] coolcamilla:** Whatever you want.

**[08:14] Customer:** Okay. I’ll live here.

**[08:20] coolcamilla:** Everything inside the white borders needs to be dug out. Now you can-it turns out-just press C to enter climbing mode. Now, with W, it kind of moves forward. With S, it moves down. Well, backward. Here, with A it rotates counterclockwise, and with D, clockwise.

**[08:49] Customer:** I want to... go up into the sky.

**[08:52] coolcamilla:** Okay, and also try doing this in climbing mode-like, pressing C and digging at the same time, for example.

**[09:00] Customer:** Is that possible?

**[09:01] coolcamilla:** See? It’s not possible.

**[09:03] Customer:** Oh, I was just trying to do that, too.

**[09:06] coolcamilla:** Oh, well, that’s impossible. And if you press C again, it turns out he exits the climbing mode.

**[09:13] Customer:** Man, that’s all well and good, but why are the branches in the ground? I’m just going to keep asking this. I get why the branches are there. But why are they in the ground?

**[09:27] SunrisEe41:** It’s just that if… then we’d have to leave only the saplings.

**[09:30] Customer:** Man, that’s cool. I’d like some valuable blocks. I mean, so there’s actually some value to them. Otherwise, yeah, you can’t see what’s there… But they’re all the same.

**[09:47] coolcamilla:** Well, no, in the second layer… yeah, deposits have appeared there. I just don’t have the sprites yet.

**[09:55] Customer:** Man, that’s cool.

**[10:07] coolcamilla:** Oh, wait-do you have 10 branches?

**[10:12] Customer:** What?

**[10:13] coolcamilla:** Do you have 10 branches yet? Press F to open it.

**[10:17] Customer:** Guys... please fix the interface. It’d be better... well, to just specify right here what’s needed and buy it right away. Without all this... You want to enter it, just enter it when you hover over it... later.

**[10:38] coolcamilla:** Well, anyway, yeah, the shovel’s crafted.

**[10:41] Customer:** Man, I’m going to make a pickaxe right now. Like, and I’ll make this… And actually, I’ll make this too…

**[10:49] coolcamilla:** No, you won’t be able to do that.

**[11:00] Customer:** Guys, I’d also like to be able to move the mouse around.

**[11:03] WazzuRunaway:** Yeah, yeah, yeah.

**[11:15] coolcamilla:** Okay, now... that’s a skip... Well, it turns out you can go for the drill-try leveling up the drill.

**[11:27] Customer:** Throw in some kind of perk, please.

**[11:30] coolcamilla:** Let’s do stamina first, by the way. So basically, here’s how stamina works: when he’s climbing… exactly… when he’s climbing, it gets used up whenever he presses either W or S. So, as soon as his stamina runs out, he starts moving very slowly.

**[11:58] Customer:** Wow, that’s cool. Make it really small then. To start with. We’ll level it up later.

**[12:04] coolcamilla:** Right, yeah. And it replenishes when he’s not climbing.

**[12:10] Customer:** Guys, think of some kind of gimmick for the setting. Something you can come up with next time that’ll make people go, “Whoa! We actually came up with something like that.” We actually have a mole… I don’t know… an anarchist… who wants to destroy the local system… destroy nature. Yeah… it’s… a mole who hates nature because when he was a kid… nature took his parents away. And now he’s become a capitalist who lives in a house… Please, something like that. Well, something cool to sell. Just with words. Okay, now we can make the best ice axe in the world. And the best ice axe in the world.

**[13:06] coolcamilla:** Doesn’t it drop there yet?

**[13:08] SunrisEe41:** No...

**[13:10] Customer:** Let’s just assume we can make it.

**[13:12] coolcamilla:** Well, it’s all already designed there, it’s just that... Well, everything’s already there, it just doesn’t drop.

**[13:21] Customer:** Guys, please, Phil. Phil, Phil, Phil. The blocks disappearing. Right now, the blocks disappear in a boring way. When you make the blocks disappear in a cool way, you’ll want to play it forever. Just moving back and forth. Maybe you could add some lighting effects... a nice animation as they shrink. ..

**[13:42] coolcamilla:** Well, there’s already an animation. We’re adding cracks, yeah.

**[14:00] Customer:** Just take a look at how it’s done in *SteamWorld Dig*, how it’s done in *Forager*. How it’s done in *Stardew Valley*. You can look up how it’s done in niche games like that.

**[14:21] SunrisEe41:** Just add a camera shake when blocks break.

**[14:24] Customer:** No, no, damn it

**[14:25] SunrisEe41:** Particles.

**[14:26] Customer:** We need particles. You can test out the camera shake. Screen shake, because that kind of thing is very... Well, like, if it’s constant, you’ll die for nothing. Damn... Oh well. Most importantly, I’d like to see... Good job adding the range. I’d like to see some ambiguity.

**[14:55] SunrisEe41:** I think there’s coal over there...

**[14:57] Customer:** Coal? Where?

**[14:58] WazzuRanaway:** That gray block over there.

**[14:59] coolcamilla:** Oh, really? Do they spawn? I was just digging around when... Well, I was checking out those fences and stuff. I was digging around, but I didn’t find anything in the stone. Well, I didn’t spend much time in the stone.

**[15:16] Customer:** Anyway, yeah, it’s cool that there’s already some ambiguity-it might even make sense to have the blocks disappear… Well, specifically, so they wouldn’t stay visible. Or, well… By the way, overall, yeah. And set up a visibility timer so the blocks stay visible for a while. Then the mole forgets about them, because the mole also… doesn’t remember anything, right. He’s blind, dumb… Just a bum. An anarchist-let’s not forget. Anyway, yeah, play around with that-it’s already way better and way more fun now. You should find a good animator. You can write to the Art House of Innopolis University club. Show them the project and say, “We need an animator for the mole.” Well, or I can recommend some chat rooms there. The ones where you can show the project and say, “Here, we’re making a demo.” Just to make it look good.

**[16:38] coolcamilla:** Lilia Shagidullina does all our artwork.

**[16:41] Customer:** Do you draw? Okay, then we’ll need to… First of all, I’m sorry… And second, we’ll need to really fine-tune it to fit the gameplay. Because I looked at the outline, and this kind of outline is exactly what JP artists love to do. I mean, it’s… See that white border? It’s on the mole right now. We’ll have to figure out how to make it fit the art style that goes with the blocks. Man… No, if you have an artist-that’s all good.

**[17:33] Customer:** Okay, so we still need to discuss the architecture, right?

**[17:35] coolcamilla:** Yeah. Can you take a quick look at the drill too? Just to make sure it’s working-that’s all. See if there’s anything else about the drill you think needs changing. It hasn’t changed much since last time.

**[17:50] Customer:** Oh, and we still need to fix the bug where the tiles are visible at the edges... You know, that glow... Or here’s a request for you... Go ahead, guys. Tear it down, destroy it. But make this project look great. Watch what they’re doing. Please, please. Here... The drill should be the central element... . I mean, in the center of the level. Well, you guys get it-it’s kind of like… As for the rest… Better to have just one button.

**[18:50] WazzuRunaway:** Yeah, yeah, that’s right. I mean, right now it’s just one interface element. It’s more of a placeholder right now.

**[18:56] Customer:** Yeah, we need to play around with the interface. The idea here is great; I like it. Especially if we can improve the mole feature and implement it… It’ll be top-notch overall.

**[19:09] SunrisEe41:** Have you seen the inventory?

**[19:10] Customer:** No, is it… here? The inventory is generally good-just a basic display. Like in *Forger*. It’s still visible to the player anyway. The player needs to see what they’re going to do next. To understand… you know, whether they’ve collected anything, and then switch to the dashboard like that. It’s really necessary. In short, you have Forager. You have SteamWorld Dig.

### UAT session ends

**[20:05] SunrisEe41:** We’ve created architecture documentation. We have a static view of the documentation-it’s a component diagram, meaning classes and how they interact with each other, scripts…

**[20:24] Customer:** Can you show it to us?

**[20:26] SunrisEe41:** Sure. Okay, here’s the component diagram. We’ll probably need to make it full screen somehow. There are a lot of details. Yeah, there’s a lot here, I think, right here on

**[20:24] Customer:** Wow, that’s awesome.

**[21:26] SunrisEe41:** This is still based on last week’s MVP.

**[21:38] Customer:** Who put this together?

**[21:40] SunrisEe41:** A combination of me and Claude Pro.

**[21:47] Customer:** Okay, that explains a lot. So basically, you gave him the Unity code and started begging him to turn it into a diagram.

**[22:06] SunrisEe41:** Yeah. I’ll need to clean it up some more. There’s also a Deployment Diagram, but our deployment isn’t particularly complicated. Here’s the Development Machine-it goes through CI here, and then a person downloads it.

**[22:42] Customer:** Claude can do that, yeah.

**[22:30] SunrisEe41:** So, this is our Sequence Diagram-the sequence of how the player digs. That is, what happens when the player digs. What gets checked, what gets calculated...

**[23:17] Customer:** Were you asked to make this, too?

**[23:20] SunrisEe41:** Yes.

**[23:22] Customer:** Why digging, specifically?

**[23:24] coolcamilla:** Well, we had to create it for a single scenario, but the most fundamental one. And the game is essentially built around the act of digging itself.

**[23:33] Customer:** Yeah, on the digging itself. The philosopher mole...

**[23:39] coolcamilla:** Actually, it’s all happening inside the mole’s head. He’s trying to dig his way to the core of his consciousness.

**[23:45] Customer:** Yeah, he’s working through his traumas in therapy.

**[23:49] SunrisEe41:** And what’s the drill bit?..

**[23:51] coolcamilla:** Those are the thoughts devouring his brain. And the beer is like pills-it’s paid for with coins.

**[23:59] SunrisEe41:** No, the beer is actually real beer in real life. The mole is just drinking it.

**[24:03] Customer:** Well, or a session with a therapist who makes him go deeper and deeper into himself every time.

**[24:10] SunrisEe41:** It’s like we’re playing a game that’s an analog horror experience.

**[24:12] Customer:** Yeah, yeah, yeah! Nothing wrong with that-it’s totally awesome. I know you all want to create an analog horror experience somewhere inside yourselves here. No matter how much you try to hide it.

**[24:24] coolcamilla:** Oh, we also need to talk about ADR.

**[24:28] SunrisEe41:** Yeah, that stands for Architecture Decision Records. First off, the first architectural decision is that we’re using Unity as our engine. This is confirmed by the fact that we discussed it in both the first and second interviews.

**[24:48] Customer:** Don’t you want to switch?

**[24:50] coolcamilla:** Yeah, sure, it’s about time. (jokingly)

**[24:55] Customer:** We’ve had that happen with other teams.

**[25:01] SunrisEe41:** That’s not going to happen to us. So, ADR-002 is that we use singletons without MonoBehaviour. This is to enable testing, ensure independence, and allow for debugging. And to prevent things from breaking overall when everything is rendered. And finally, ADR-003: the game logic itself also needs to be separated from MonoBehaviour into pure C# classes.

[Unrelated to the interview]

**[27:00] coolcamilla:** And the last thing we need to discuss is the gaps, the risks, and what we’re actually planning to do. As I mentioned, we’re thinking about how to diversify movement. So far, two ideas have come to mind. First, we could make, for example, some kind of ring… Anything, basically, so that if the mole stands on a certain block, it can somehow change its properties. So, if it stands on a dirt block, it turns into stone.

**[27:39] WazzuRunaway:** Or it turns into gold.

**[27:42] Customer:** That sounds funny. There’s something to that-think about it.

**[27:46] coolcamilla:** We’ll probably have a beer vending machine, too. And beer for coins. And we could make it so that coins drop very rarely, but if he needs more coins...

**[27:56] Customer:** Put coins in the blocks, please. Give the player a sense of purpose.

**[28:00] coolcamilla:** Well, the coins are already drawn. And I also had an idea to make boots that change gravity. So, for example, he’s standing underground, and he needs to… well, let’s say he has a pit that’s about 5 blocks deep. It’s hard for him to reach the ceiling, but he really needs to dig from above. So he puts these on, his gravity changes, he sticks to the ceiling, and then he kind of digs the other way around.

**[28:27] Customer:** Not everyone will get it.

[Inaudible]

**[28:35] coolcamilla:** Also, we just remember that you mentioned the rollbacks. I don’t know what to do with them.

**[28:46] Customer:** You could add a character who returns to Earth and gives away all his... savings. Like that. And triggers some dialogue... Instead of the cutscenes...

**[28:59] coolcamilla:** Well, there was actually another idea-though this is clearly beyond the scope of the project now... There’s a game called “There is no game” where there was a narrator who talked constantly. So, I had this idea to create a narrator who constantly comments on the mole.

**[29:24] Customer:** Did you know that the developers of “There is no game” recently released a game about Sherlock Holmes? Here’s the gist: you and Watson have to find the missing character from the game right before its announcement. We’re inside the game project, and we have to investigate why the main character disappeared.

**[29:46] coolcamilla:** That’s cool. Well, basically, something like that is still just... But we probably won’t have time to get it done by the deadline.

**[29:55] Customer:** What about making it in 3D?

**[30:00] coolcamilla:** Well, we actually considered 3D right at the very beginning. In terms of design, we actually wanted to go with a Paper Mario style at first.

**[30:09] Customer:** Man, why didn’t you go with that?

**[30:11] coolcamilla:** No, well, we basically did go with Paper Mario.

**[30:15] Lilia-Shagidullina:** That’s what the game designer said.

**[30:16] Customer:** Seriously, why didn’t you just beat him up? I mean… come on, Paper Mario is totally overpowered. Stylistically, it’s not complicated at all, and it’s just a blast. And it’s so cool, it’s insane. Just beat up the game designer and redraw it. Well, overall, there are still some echoes of that style now. We need to, well… We need to redraw it really drastically…

**[30:38] coolcamilla:** And there was another crazy idea, of course. But the idea was that when he’s underground, everything is in 2D. Like, as soon as he comes to the surface, it’s 3D.

**[30:48] Customer:** Awesome, sold, all right, that’s amazing. Okay, got it. That’s great.

**[30:52] coolcamilla:** Yeah, I know it’s amazing, but we just won’t have time to do it.

**[30:56] Customer:** No, I get it. If you do it later, that’d be cool. If you develop it further. When we made Gigachad, we also worked out a concept where, while you’re fighting down below, everything is 2D. When you rise up into the sky, everything there is sort of first-person. Well, it’s still 2D, but it’s in 2.5D.

**[31:18] coolcamilla:** Yeah, yeah, yeah, that’s what we… Well, we were thinking of something like 3D, but where it could still only move in one direction. I mean… It all looks 3D, but essentially it’s still just…

**[31:26] Customer:** Well, everything faces the player. Yeah, that’s 2.5D. That’s what I’m talking about, yeah. Like, that’s totally awesome-you should do that. Especially if you go with a cartoon style and figure out how to…

**[31:34] coolcamilla:** Well, that was our original idea.

**[31:37] Customer:** That’s it-just kick the game designers off the team and do everything yourselves. I mean, guys, you have examples, you’ve all played Forager already... With the game designer... don’t let him...

**[31:54] coolcamilla:** Marat writes the music for us. Marat writes, writes... writes and writes... I don’t even know... I just don’t know, honestly. I kind of have to pretend that everything works more or less the same way for us. And Marat just wrote music every week... Wrote music... He was writing music...

**[32:13] Customer:** Guys, we don’t really need music for the demo. I mean, it’s no big deal-any kind will do. But the thing is... I just don’t understand what he’s doing. He’s supposed to be improving the project... Yeah, how it’s all supposed to be... Not just drawing it, but specifically how it should be laid out…

**[32:37] SunrisEe41:** Well, we’d be happy to send it to the documentation team.

**[32:41] Customer:** But? That’s what he’s supposed to be doing.

**[32:44] SunrisEe41:** But the ratings depend on it.

**[32:45] Customer:** And he’s with you…

**[32:46] coolcamilla:** Well, it’s a little scary to send him over.

**[32:50] SunrisEe41:** But we don’t always have time to finish it ourselves.

**[32:56] Customer:** That’s why you sent him to sound design. What should we do next? Have him go draw the sound effects.

**[33:12] coolcamilla:** Right. Okay. Now... About the visual backlog... features...

**[33:20] Customer:** Let him go for a Paper Mario style... That’s interesting.

**[33:26] SunrisEe41:** I think overall... The only thing that could be done to make the game better-if you happen to continue working on it after this project-is to switch to that 2.5D style once he gets out of the pit, just as you originally planned. And… that’s it. So there’ll be a 2.5D surface and a 2D pit.

**[33:45] Customer:** And don’t restore stamina, and end the cycle. That’s it.

**[33:50] SunrisEe41:** Don’t restore stamina?

**[33:52] Customer:** Well, yeah-I mean, if you don’t make it out in time, the mole dies down there…

**[33:56] SunrisEe41:** And it goes back up.

**[33:59] Customer:** I think we’ve seen this somewhere before...

**[34:02] coolcamilla:** Does it keep its resources, or does everything reset to zero?

**[34:06] Customer:** Well, it resets to the last one.

**[34:07] WazzuRunaway:** Back to the last run. We could add another warehouse or something.

**[34:10] Customer:** But of course, we’ll have to balance it so it doesn’t happen that a player dies a million times and…

**[34:19] WazzuRunaway:** And they run out of resources.

**[34:20] Customer:** Yeah. You could just scatter them around down below somewhere.

**[34:25] coolcamilla:** Well, there you go... Or have it save if they manage to run there in time. Like in Minecraft, basically.

**[34:35] Customer:** But then it’ll just be a loop. Because if it keeps switching between 2D, 3D, 2D, 3D every time… and the player dies… with this, you’ll actually have immersion, exploration, discovery… and risk.

**[34:48] coolcamilla:** Well, the risk is that next week we’ll have this beer, and it turns out it gets hot. I don’t know how big a risk that is.

**[34:55] Customer:** Why?

**[34:56] coolcamilla:** Just to have it there.

**[35:00] Customer:** Do the risk mechanic without that. Or you could add some kind of... some kind of creature, some kind of hole that chases, say, a mole. Well, if you want something cheap and simple. Because the mechanics... What you described are mechanics that require health to be tracked. Mechanics that will require additional interactions with the systems. I mean… What happens when you destroy the saw block there? Apparently, above you, not below you…

**[35:38] coolcamilla:** Make it so that if his stamina runs out…

**[35:41] Customer:** Yeah, that’s it, he… Over there.

**[35:51] SunrisEe41:** On the surface, like, there’s a risk mechanic. There’s a drill on the surface. Sometimes it just throws huge rocks. Like, he’s digging, digging, bam-a huge rock just flies at the mole.

**[36:07] coolcamilla:** Okay, I’ll ask a few more questions. How many resources should there be per layer? I mean, right now on the surface we only have dirt and clay blocks.

**[36:20] Customer:** Please, make it infinite. Not literally infinite-you get what I mean, right? Make it so there aren’t...

**[36:33] coolcamilla:** So there aren’t these white walls. Okay. There you go.

**[36:40] Customer:** You can generate them. Since it’s all very Paper Mario-esque, you can take the clouds and the sky right from there...

**[36:52] coolcamilla:** Right. Next, we finally want to add at least a second layer. I mean, so that the drill actually... well, there’s a transition to the next layer thanks to the drill, and the mining stations. Those untextured squares over there are like ore deposits. He places... He places a harvester, and resources just automatically drip out of them. Then he puts those resources back into the drill. Well, he upgrades it. And so on.

**[37:30] Customer:** Can you actually implement inventory limits? Was there a limit on the number of resources in Forager?

**[37:43] WazzuRunaway:** Yeah, you’re constantly running out of slots.

**[37:47] Customer:** Well, that’s cool.

**[37:48] WazzuRunaway:** You have to destroy something.

**[37:51] SunrisEe41:** You have to spend two hours organizing your backpack.

**[37:54] Customer:** We could come up with something like that. You know, so the player wants to come back. Otherwise, they’ll just keep digging endlessly and then log out. You don’t want that.

**[38:07] coolcamilla:** I also had the idea that beer could affect stamina somehow. I mean, hypothetically, when they drink beer, their stamina would recharge faster...

**[38:19] Customer:** You can level it up. You run around, drink beer, and your stamina is always leveling up. Yeah, great. Just like a potion, sort of. Well, yeah, a mole’s stamina booster… Essentially, it turns out to be very metaphorical-a simulator of a man over 40 who’s dealing with his traumas, drowning them in alcohol, and digging deeper and deeper into himself. You’re actually making a Skuf simulator, but we won’t tell anyone that. For everyone else, it’s a Paper Mario-style game about a mole.

**[38:56] coolcamilla:** Well, that’s about it, then. Okay.

**[39:00] Customer:** Can you let us listen to the music?

**[39:05] coolcamilla:** Is there even any music? Well, I mean, Marat has some somewhere.

**[39:09] Customer:** Oh, he hasn’t even sent it to you yet?

**[39:15] WazzuRunaway:** He’s got something there. It’s been a week already.

**[39:19] Customer:** Why do you even need a game designer like that? Just fire him. Because you’ve got a really cool concept.

**[39:33] coolcamilla:** The funny thing is that Marat actually came up with this concept. Okay, let’s make our own game, swap the mole for… a Skuf. Yeah.

**[39:56] Customer:** Damn. I think… Someone won’t be ready to draw a Skuf… But it was sold. It could’ve been done in a way that would’ve worked… So we can do [Inaudible]…

**[40:18] SunrisEe41:** If you drink a thousand beers, you’ll have “Operation: SkufCore” on the main menu. So, is there anything else?

**[40:22] coolcamilla:** I don’t think so. Well, that’s it for me. That’s it for everyone. That’s it for everyone. That’s it for everyone.

[Unrelated to the interview]

End of the Interview

  
  
  
  
**
