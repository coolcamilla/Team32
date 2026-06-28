## Learning Points
- EditMode Unity tests are analogous to unit tests, and PlayMode Unity tests are analogous to integration tests.
- Setting up CI for a Unity project was significantly harder than for a typical web app. Industry best practices often need adaptation for game engines.
- UAT testing revealed that while mechanics work correctly, the game lacks engagement and fun. Tests alone could never have caught this problem, proving that UAT sessions are essential for validating game feel, not just technical correctness.
- Allowing the customer to explore the product freely, rather than following a strict step-by-step instructions, proved far more effective at surfacing bugs.
## Validated assumptions
- We assumed that drag-and-drop items reallocation would be useful for drill fueling - rejected during the UAT session
- We assumed that only the drill should allow the mole to move to a new level - confirmed during the Sprint Review with the customer
- We assumed that the size of the game character should be 1 block - confirmed during the MVP v2 playtest
- We assumed that overheating should be a risk mechanic - confirmed during the Sprint Review with the customer.
- We assumed that all jump bugs were fixed - rejected during implementation.
- We assumed that writing tests by several programmers would be effective - rejected during the CI setup.
## Friction and gaps
- game content is not wide enough
- game lacks engagement
- inventory and crafting UI are overcomplicated
- code needs substantial refactoring
- unit tests have low line coverage beacuse they are not applicable in many cases
## Planned response
- Fix all jump bugs ([#168](https://github.com/coolcamilla/Team32/issues/168))
- Introduce interesting movement mechanics
- Add limited visibility ([#154](https://github.com/coolcamilla/Team32/issues/154))
- Add overheating ([#153](https://github.com/coolcamilla/Team32/issues/153))
- Add stamina to the mole ([#167](https://github.com/coolcamilla/Team32/issues/167))
- One person is reasonable for testing
