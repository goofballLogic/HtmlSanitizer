#Resource inlining

These tests verify that resources external to the supplied HTML are successfully downloaded and embedded as part of the HTML. Mechanisms include converting stylesheets to inline <STYLE> blocks, and encoding images as data URIs.

##Elements which must be inlined:

1. CSS
	v LINKed stylesheets	
	v @imported stylesheets
	v font-faces
	- behaviour
	- -moz-binding
	- nested @import statements
	- possible duplicate statements
	- append to existing style tag
	- @media ?
	- @document

2. Images
	- IMG tags
	- CSS contained images
		- background-image
		- border-image
		- list-style-image
	- SVG ?


## Cross-cutting concerns

1. BASE tag
	