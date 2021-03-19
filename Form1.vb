Public Class Form1
    Private Sub SignInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignInToolStripMenuItem.Click
        grpCheckIn.Visible = False
        grpPurchaseInformation.Visible = True
        grpAppetizers.Enabled = True

        chkImageVisable.Visible = True
        txtDescription.Visible = True
        rtbWelcome.Visible = True

        rtbWelcome.Text = "Welcome, " & txtName.Text & "." & System.Environment.NewLine & "ID: " & mtbMemberID.Text

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub mtbMemberID_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtbMemberID.MaskInputRejected
        mtbMemberID.SelectionStart() = 0

    End Sub

    Private Sub chkImageVisable_CheckedChanged(sender As Object, e As EventArgs) Handles chkImageVisable.CheckedChanged
        If chkImageVisable.Checked = True Then
            picAppetizers.Visible = True
        Else
            picAppetizers.Visible = False
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            Me.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub rdoSampler_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSampler.CheckedChanged
        If rdoSampler.Checked = True Then
            txtDescription.Text = "Choose from: calamari, stuffed mushrooms, fried zucchini, chicken fingers, or fried mozzarella.”
            picAppetizers.Image = My.Resources.Sampler
            txtSalesPrice.Text = "20"
        End If
    End Sub

    Private Sub rdoFrita_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFrita.CheckedChanged
        If rdoFrita.Checked = True Then
            txtDescription.Text = "Parmesan-breaded lasagna pieces, fried and served over Alfredo sauce, topped with parmesan cheese and marinara sauce."
            picAppetizers.Image = My.Resources.Fritta
            txtSalesPrice.Text = "12"
        End If
    End Sub

    Private Sub rdoBruchetta_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBruchetta.CheckedChanged
        If rdoBruchetta.Checked = True Then
            txtDescription.Text = “A traditional topping of roma tomatoes, fresh basil and extra-virgin olive oil. Served with toasted ciabatta bread.”
            picAppetizers.Image = My.Resources.Bruschetta
            txtSalesPrice.Text = "15"
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim qty As Int16
        Dim price As Decimal

        Int16.TryParse(txtQuantity.Text, qty)
        Decimal.TryParse(txtSalesPrice.Text, price)
        txtTotalAmount.Text = (qty * price).ToString("C")
    End Sub

End Class
