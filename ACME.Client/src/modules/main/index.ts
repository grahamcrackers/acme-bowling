import { Utils } from "lymph-client"

jQuery.ajax( "http://localhost:8081/api/greeting", {} ).then( function ( response ) {
    $( "#message" ).html( response.text )
} )

$( "#greeting-form" ).on( "submit", function ( e ) {
    e.preventDefault()

    const { name } = Utils.extractFormData( this )

    jQuery.ajax( `http://localhost:8081/api/greeting/${ name }`, {} ).then( function ( response ) {
        $( "#message" ).html( response.text )
    } )
} )