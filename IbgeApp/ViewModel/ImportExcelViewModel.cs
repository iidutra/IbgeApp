using Microsoft.AspNetCore.Components.Forms;

namespace IbgeApp.ViewModel
{
    public class ImportExcelViewModel
    {
        private readonly HttpClient _httpClient;

        public ImportExcelViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool IsUploading { get; private set; }
        public string StatusMessage { get; set; }

        public async Task UploadFileAsync(IBrowserFile file)
        {
            IsUploading = true;
            StatusMessage = "Iniciando upload...";

            try
            {
                Console.WriteLine("Upload iniciado para o arquivo: " + file.Name);

                using var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream());
                content.Add(fileContent, "file", file.Name);

                Console.WriteLine("Preparando para enviar a requisição HTTP.");
                var response = await _httpClient.PostAsync("upload", content);

                Console.WriteLine("Requisição HTTP enviada. Status: " + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    StatusMessage = "Upload concluído com sucesso!";
                }
                else
                {
                    StatusMessage = "Falha no upload do arquivo. Status: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceção capturada: " + ex.ToString());
                StatusMessage = "Erro ao tentar fazer upload do arquivo.";
            }
            finally
            {
                IsUploading = false;
                Console.WriteLine("Status do upload: " + StatusMessage);
            }
        }

        public async Task UploadFileFromBase64Async(string base64String, string fileName)
        {
            IsUploading = true;
            StatusMessage = "Iniciando upload...";

            try
            {
                var bytes = Convert.FromBase64String(base64String.Split(',')[1]);
                using var stream = new MemoryStream(bytes);

                using var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(stream);
                content.Add(fileContent, "file", fileName);

                var response = await _httpClient.PostAsync("upload", content);

                if (response.IsSuccessStatusCode)
                {
                    StatusMessage = "Upload concluído com sucesso!";
                }
                else
                {
                    StatusMessage = "Falha no upload do arquivo. Status: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Erro ao tentar fazer upload do arquivo: " + ex.Message;
            }
            finally
            {
                IsUploading = false;
            }
        }

    }
}
