#Resource inlining

These tests verify that resources external to the supplied HTML are successfully downloaded and embedded as part of the HTML. Mechanisms include converting stylesheets to inline <STYLE> blocks, and encoding images as data URIs.

##Elements which must be inlined:

1. CSS
	- LINKed stylesheets	
	- @imported stylesheets
	- font-faces
2. Images
	- IMG tags


## Cross-cutting concerns

1. BASE tag
	