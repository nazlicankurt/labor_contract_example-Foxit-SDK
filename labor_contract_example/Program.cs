using System;
using System.Drawing;

using foxit.common;
using foxit.common.fxcrt;
using foxit.pdf;
using foxit.pdf.actions;
using foxit.pdf.annots;
using foxit.pdf.interform;

namespace labor_contract_example
{
    class Program
    {
        private static string output_path;

        public static void AddInteractiveForms(PDFPage page,Form form)
        {
            {

                // Set default appearance
                using (DefaultAppearance default_ap = new DefaultAppearance())
                {
                    
                    default_ap.flags = (int)(DefaultAppearance.DefAPFlags.e_FlagFont | DefaultAppearance.DefAPFlags.e_FlagFontSize | DefaultAppearance.DefAPFlags.e_FlagTextColor);
                    using (default_ap.font = new foxit.common.Font(foxit.common.Font.StandardID.e_StdIDHelveticaB))
                    {
                        default_ap.text_size = 12.0f;
                        default_ap.text_color = 0x000000;
                        form.SetDefaultAppearance(default_ap);
                    }

                }
            }



            {
                // Add text field, with flag multiline.
                using (Control control = form.AddControl(page, "Text Field3", Field.Type.e_TypeTextField, new RectF(230f, 710f, 320f, 740f)))
                using (Field field = control.GetField())
                {

                    field.SetFlags((int)Field.Flags.e_FlagTextMultiline);
                    field.SetValue("Labor Contract");
                 
                }
                using (Control control = form.AddControl(page, "Text Field4", Field.Type.e_TypeTextField, new RectF(50f, 580f, 550f, 650f)))
                using (Field field = control.GetField())
                {
                  
                    field.SetFlags((int)Field.Flags.e_FlagTextMultiline);
                   field.SetValue("Text fields are boxes or spaces in which the user can enter text from the keyboard.");
                  
                }
            }

          

            {
                // Add list box
                using (Control control = form.AddControl(page, "List Box0", Field.Type.e_TypeListBox, new RectF(50f, 450f, 350f, 500f)))
                using (Field field = control.GetField())
                using (ChoiceOptionArray options = new ChoiceOptionArray())
                {
                   options.Add(new ChoiceOption("Female", "Female ", true, true));
                   options.Add(new ChoiceOption("Male", "Male", true, true));
                   options.Add(new ChoiceOption("Other", "Other", true, true));
                   field.SetOptions(options);

                }
            }

           
           
        }
        static void Main(string[] args)
        {
            // The value of "sn" can be got from "gsdk_sn.txt" (the string after "SN=").
            // The value of "key" can be got from "gsdk_key.txt" (the string after "Sign=").
            string sn = "jN9RZk8LJuK6QjH+MqayQOhLAEk+TQ/S+RU1IjRhwKbL0itfC6rseQ==";
            string key = "8f0YFUGMvRkN+ddwhrBxubRv+38GzmILMEDAmlEsyRrKr+XwdTI+7gO6BP1L+TnTSwrh+Zzoe5xbo3VQ/z/ywRSgkjMZFgITx5YCsQKiv6JuhEyeWn0I6qr2VIHHVlVHE554uDO+k5p4x+9MhUEkQXIEPVCKKkLIQXq5k+SQTB5DTXxxumVjRVIxZffyUgUh11sSUSm4m7hAoGIAQf6k0S33wq3Hbqg/BvyXZAXq3MAD5dXj64bjJPjwuJf230lfJP7jCtw79g86b+3nlLoKaTU5mIvmYtMUqYmjJCSnoq+0AWqqYFKXdh32Rg/DRm8WjXR7RUWDlHFQeenQooLk7kztEudDJmLbjjeLp2hvxJ0f8/hCfFWKgcHEss0su5tXryTSWNdMG7v0Wn3UKm0qr+QttiHJMqvCZGzMxYYiw2b70V0DFtczQV0QrJ40hcYs6+zZY46KV4eStf1ZFQlrzTnSTZwnzO87S6VvPFw+dWnvTDCHn3QEB5K5NM5ZiFaWQAEeM7EwEvV1AheUdKPb41fiwDnxP1pLRd53TnqMWHtwHv/avpW2q9nMFFb+5bmdj65EKM5h0zph41m8hjBTBEQat+qjyqqFN2HTmWU7UIlZHOX9O4HBmQ9e74LTBGDyn+wDaDkGzvAwhEQ7LuHPdByO4jb9M6SEwFdoi6yt82C330mLr900p6kpyWL4GfuxvK6Ltb+AHKy6mBhb+l22pXfCOva8tw+DU5VrmkR4MmFF9npOVA9Q06PO5IypL99SdCeeqjDrp+XQBpU8EGrvqt88d7eKUjrmmT7Qh0LlfghDQyglIoAvwhcN9c9UlHd6axWxlTC7PtyGkW0UZpKfVFXiCOVYdSAEaO/4mt+s4xQnqJtK/+AVyfJqsWR8DyEJo0RcIjiC8R3lmc8tT+gxAEb89GogKEbC665WRH93m3k6hEj5VBBYoL7yt5Mck+nf+ieDRYwBw0tDja9bLC/G8KtzbbW1eJpHAhSV/2Q2w9Z0gPBAQAXUJCjjb/dqwDiKsZyfbz/2jV8tCOlDXPrSvcLlgINO1+pLicNvoNl/53QqbB6KdJNMvxvMVfpPDnSqa+TXCYbVClwGzE4mkrITX47qDmGYHs1izzlH4PpH4uSE+cj0y8Br7fxZ2f9wJvcs59bGFZsE2I2NU3GlscGRk6u9XKBwTydmOn0evegFCPic17VH2kcukffJTofktpZYOfvdUw+eqc50CD2gg1oPHLohXJ1b/ueQIIaM7l009NxXDTCmwJ/cCAnIMoDD6/dehYLGa7uRv3pSI9zQPVOzfE86Z4PH9WHQXz1lsz8T+ECUBiqOaVH5d7gI";
            ErrorCode error_code = Library.Initialize(sn, key);
            if (error_code != ErrorCode.e_ErrSuccess)
            {
                return;
            }

            try
            {
                using (PDFDoc doc = new PDFDoc())
                using (Form form = new Form(doc))
                {
                    // Create a blank new page and add some form fields.
                    using (PDFPage page = doc.InsertPage(0, PDFPage.Size.e_SizeLetter))
                    {
                        AddInteractiveForms(page, form);
                        string new_pdf = output_path + "labor11_contract.pdf";
                        doc.SaveAs(new_pdf, (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal);
                    }
                }
            }
            catch (foxit.PDFException e)
            {
                Console.WriteLine(e.Message);
           


        }
        Library.Release();
        }
    }
}