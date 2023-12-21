window.uploadFile = (elementId) => {
    return new Promise((resolve, reject) => {
        let input = document.getElementById(elementId);
        if (input.files.length === 0) {
            reject("Nenhum arquivo selecionado.");
        } else {
            let file = input.files[0];
            let reader = new FileReader();
            reader.onload = (event) => {
                resolve({
                    data: event.target.result,
                    name: file.name
                });
            };
            reader.onerror = (event) => {
                reject("Erro ao ler o arquivo.");
            };
            reader.readAsDataURL(file);
        }
    });
}
