/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    // config.removePlugins = 'Underline,Subscript,Superscript,Smiley,iframe,about';
    
    //config.removeButtons = 'Smiley';
    //config.removePlugins = 'iframe,about,dialog,removeformat,specialchar,sourcearea,save,newpage,preview,print,div,templates,paste,pastefromword,pastetext';
    config.removePlugins = 'blockquote,save,flash,iframe,tabletools,pagebreak,templates,about,showblocks,newpage,language,print,div';
    config.removeButtons = 'Print,Form,TextField,Textarea,Button,CreateDiv,PasteText,PasteFromWord,Select,HiddenField,Radio,Checkbox,ImageButton,Anchor,BidiLtr,BidiRtl,Preview,Source,Undo,Redo,Cut,Copy,Paste,Find,Replace,SelectAll,Scayt,Link,Unlink,Image,Table,Smiley,TextColor,BGColor';


};
