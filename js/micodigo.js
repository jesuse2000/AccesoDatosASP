function msgbox(ti, texto, icono) {
    Swal.fire({
        title: ti,
        text: texto,
        icon: icono,
        confirmButtonText: 'Aceptar'
    })
}