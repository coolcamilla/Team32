## Learning Points

- Documenting architecture through multiple views (static, dynamic, deployment) shows the number of dependencies between components that could not be seen beforehand
- ADRs are most useful when written at the moment a decision is made, not reconstructed after the fact
- UAT sessions are more valuable when the customer is given free exploration time in addition to structured steps. Unscripted play revealed UI problems and visual gaps that the step-by-step scenarios did not cover
- Delivering MVP v2 early in the Sprint created meaningful slack time for documentation and testing, confirming that implementation-first scheduling with a buffer at the end is more effective than parallel work throughout
- PR and Merge CIs have different purposes which could lead to unseen circumstances

## Validated assumptions

- We assumed that simplifying the crafting flow to a single-tool chain would be easy to use for the players - confirmed during the Sprint Review
- We assumed that limited underground visibility would improve the sense of exploration - confirmed during the Sprint Review
- We assumed that the overheating should be the risk mechanic - rejected during the Sprint Review
- We assumed that dig-pickup sequence is the primary game scenario - confirmed during the architecture documentation
- We assumed that we should sway away from the Paper Mario style - rejected during the Sprint Review
- We assumed that game controls are obvious for the new players - rejected during MVP v2 game test

## Friction and gaps

- UI layout and readability remain the most consistently flagged issue across all three Sprint Reviews; the team has not yet allocated dedicated time to UI research and redesign
- Visual feedback for block destruction (particles, shrink animation) is missing; the core digging action feels flat without it
- A tile edge glow artifact appears 
- The risk mechanic remains undefined in implementation terms — the team and customer have discussed several directions (stamina depletion consequences, falling rocks, overheating) but no concrete design has been committed
- Engaging movement mechanics for the mole are not intoduced yet

## Planned response

- Prioritise UI research at the start of Sprint 4. At least one team member will review Forager and SteamWorld Dig.
- Implement particle effects or a block destruction animation to improve the feel of the core digging loop [#205](https://github.com/coolcamilla/Team32/issues/205)
- Add a visual indicator for the corner-grab mechanic [#170](https://github.com/coolcamilla/Team32/issues/170)
- Define and implement the risk mechanic: the most likely candidate is a consequence tied to stamina depletion underground [#153](https://github.com/coolcamilla/Team32/issues/153)
- Complete sprite integration so the deposit system can be fully evaluated in the next UAT session
- Inroduce stone layer and layer transition logic [#83](https://github.com/coolcamilla/Team32/issues/83)
- Implement mining stations [#85](https://github.com/coolcamilla/Team32/issues/85)
- Implement stamina upgrading through beer [#206](https://github.com/coolcamilla/Team32/issues/206)
- Remove side walls, loop around the game world [#204](https://github.com/coolcamilla/Team32/issues/204)
