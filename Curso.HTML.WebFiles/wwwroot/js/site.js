var demo = {
    Init: {
        Ficheros: function () {
            $('#dropZone').on('dragover', function (e) {
                console.log('dragover');
                e.originalEvent.stopPropagation();
                e.originalEvent.preventDefault();
                e.originalEvent.dataTransfer.dropEffect = 'copy';
            });

            $('#dropZone').on('dragenter', function (e) {
                console.log('dragenter');
                e.originalEvent.stopPropagation();
                e.originalEvent.preventDefault();
                e.originalEvent.dataTransfer.dropEffect = 'copy';
            });

            $('#dropZone').on('drop', function (e) {
                console.log('drop');
                e.originalEvent.stopPropagation();
                e.originalEvent.preventDefault();

                var ficheros = e.originalEvent.dataTransfer.files;
                for (var i = 0; i < ficheros.length; i++) {
                    (function (fichero) {
                        if (fichero.type != '' && fichero.type.match(/image.*/)) {
                            var lector = new FileReader();
                            $(lector).on('load', function (e) {
                                $.ajax({
                                    url: '/ficheros/upload',
                                    type: 'post',
                                    data: {
                                        file: e.originalEvent.target.result,
                                        name: fichero.name
                                    },
                                    success: function (e) {
                                        if (e === 'OK') {
                                            $('#info').html('Fichero ' + fichero.name + ' registrado.').addClass("text-success  alert");
                                        }
                                        else $('#info').html('Error al registrar el fichero').removeClass('text-success').addClass('text-danger lead bad-alert');
                                    },
                                    error: function (e) {
                                        $('#info').html('Error al enviar el fichero.').addClass('text-danger');
                                    }
                                })
                            });

                            lector.readAsDataURL(fichero)
                        }
                        
                    }
                        )(ficheros[i]);
                }
            });

        }
    }
}