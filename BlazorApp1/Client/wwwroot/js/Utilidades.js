function DropdownConfirm(titulo, placeholder, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            input: 'select',
            inputPlaceholder: placeholder,
            icon:tipo,
            inputOptions: {
                'Oficina tecnica': 'Oficina tecnica',
                Punzonado: 'Punzonado',
                Plegado: 'Plegado',
                Soldadura: 'Soldadura',
                Pulido: 'Pulido',
                Pintura: 'Pintura',
                Armado: 'Armado',
                Despacho: 'Despacho'
            },
            showCancelButton: true,
            inputValidator: (value) => {
                return new Promise((resolve) => {
                    if (value) {
                        resolve()
                    } else {
                        resolve('Selecciona una etapa')
                    }
                });
            }
        }).then((result) => {
            if (result.value) {
                resolve(result.value);
            }
            else {
                resolve(null);
            }
        });
    });
}



function printDiv() {
    var divToPrint = document.getElementById('DivIdToPrint');
    var newWin = window.open('', 'Print-Window');
    newWin.document.open();
    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
    newWin.document.close();
    setTimeout(function () { newWin.close(); }, 10);
}