/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	 config.language = 'zh-cn';
	 config.uiColor = '#000';
	 config.toolbar_Full = [


       ['Source','-','Save','NewPage','Preview','-'],


       ['Cut','Copy','Paste','PasteText','PasteFromWord','-','Print', 'SpellChecker', 'Scayt'],


       ['Undo','Redo','-','Find','Replace','-','SelectAll','RemoveFormat'],

'/',
       ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
	   ['Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak'],

       '/',


       ['Bold','Italic','Underline','Strike','-','Subscript','Superscript'],


        ['NumberedList','BulletedList','-','Outdent','Indent','Blockquote'],


        ['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],


        ['Link','Unlink','Anchor'],


       


       '/',


        ['Styles','Format','Font','FontSize'],


        ['TextColor','BGColor']


    ];


 config.toolbar_Basic =
    [
        ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink','-','About']
    ];
};
