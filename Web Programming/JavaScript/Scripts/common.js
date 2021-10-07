//Custom APIs for UI DOM handling function

function $(id){

    return document.getElementById(id)

}


function $Click(id, eventHandler){

    document.getElementById(id).addEventListener("click", eventHandler);

}
function $OnClassClick(className, eventHandler){

    let classes = document.getElementsByClassName(className);

    for (let index = 0; index < classes.length; index++) {

        const element = classes[index];

        element.addEventListener("click", eventHandler);

    }

}