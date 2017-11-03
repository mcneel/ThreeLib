# Contributing
###### Inspired by [How to contribute to Three.js](https://github.com/mrdoob/three.js/wiki/How-to-contribute-to-three.js)
- Fork this repository.
- Always make your contributions for the latest `dev` branch, not `master`.
- Create separate branches per patch or feature with a sufficiently descriptive name.
- Once done with a patch / feature do not add more commits to a feature branch (pull requests are not repository state snapshots, any change you do in that branch will be included in the pull request).
- If you add a new feature it's good to add also an example (both for showing how it's used and for testing it still works after eventual refactorings).
- If you add some assets for the examples (like textures, models, sounds, etc), make sure they have a proper license allowing for their use here (less restrictive the better).
- If you modify existing code (refactoring / optimization / bug fix), run relevant examples to check they didn't break or that there wasn't some performance regress.
- If some GitHub issue is relevant to patch / feature, it's good to mention issue number with hash (e.g. #2774) in a commit message to get cross-reference in GitHub web interface.
