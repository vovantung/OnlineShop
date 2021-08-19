/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.filebrowserBrowseUrl = '/Assets/admin/ckfinder/ckfinder.html',
	config.filebrowserUploadUrl = '/Assets/admin/ckfinder/core/connector/aspx/connector.php?command=QuickUpload&type=Files',
	config.filebrowserWindowWidth= '600',
	config.filebrowserWindowHeight= '450'
};
