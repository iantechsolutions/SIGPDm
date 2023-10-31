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

